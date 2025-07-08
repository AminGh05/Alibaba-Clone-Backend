using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.DTOs.TransportationDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Aggregates.TransactionAggregates;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using AlibabaClone.Domain.Enums;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.AccountRepositories;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransactionRepositories;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class TicketOrderService : ITicketOrderService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransportationRepository _transportationRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ITicketOrderRepository _ticketOrderRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransportationLockService _transportationLockService;
        private readonly IPersonService _personService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TicketOrderService(IAccountRepository accountRepository,
            ITransportationRepository transportationRepository,
            ISeatRepository seatRepository,
            IPersonRepository personRepository,
            ITicketOrderRepository ticketOrderRepository,
            ITicketRepository ticketRepository,
            ITransportationLockService transportationLockService,
            IPersonService personService,
            IAccountService accountService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _transportationRepository = transportationRepository;
            _seatRepository = seatRepository;
            _personRepository = personRepository;
            _ticketOrderRepository = ticketOrderRepository;
            _ticketRepository = ticketRepository;
            _transportationLockService = transportationLockService;
            _personService = personService;
            _accountService = accountService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<long>> CreateTicketOrderAsync(long accountId, CreateTicketOrderDto dto)
        {
            // get the account
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null)
            {
                return Result<long>.Error(0, "Account not found");
            }

            // get the transportation
            var transportation = await _transportationRepository.GetByIdAsync(dto.TransportationId);
            if (transportation == null)
            {
                return Result<long>.Error(0, "Transportation not found");
            }

            // lock the transportation through reservation
            using (await _transportationLockService.AcquireLockAsync(dto.TransportationId))
            {
                var baseAmount = transportation.BasePrice * dto.Travellers.Count;
                if (account.Balance < baseAmount)
                {
                    return Result<long>.Error(0, "Not enough money");
                }
                // check validity of transportation
                var checkSeats = ValidateTransportationAndSeats(transportation, dto.Travellers);
                if (!string.IsNullOrEmpty(checkSeats))
                {
                    return Result<long>.Error(0, checkSeats);
                }

                var finalAmount = baseAmount;
                await AssignSeatsIfDynamic(transportation.VehicleId, dto.Travellers);
                await UpsertTravellers(accountId, dto.Travellers);

                // add the ticket order by the info we have
                TicketOrder ticketOrder = new()
                {
                    BuyerId = accountId,
                    CreatedAt = DateTime.UtcNow,
                    Description = "",
                    SerialNumber = Guid.NewGuid().ToString("N"),
                    TransportationId = dto.TransportationId
                };
                await _ticketOrderRepository.InsertAsync(ticketOrder);
                
                foreach (var traveller in dto.Travellers)
                {
                    if (!traveller.SeatId.HasValue)
                    {
                        return Result<long>.Error(0, "Seat ID is required for each traveller");
                    }

                    Ticket ticket = new()
                    {
                        CreatedAt = DateTime.UtcNow,
                        Description = traveller.Description,
                        SeatId = traveller.SeatId.Value,
                        SerialNumber = Guid.NewGuid().ToString("N"),
                        TicketOrder = ticketOrder,
                        TicketStatusId = 1,
                        TravelerId = traveller.Id,
                    };
                    await _ticketRepository.InsertAsync(ticket);
                }

                await _unitOfWork.CompleteAsync();
                await _accountService.PayForTicketOrderAsync(account.Id, ticketOrder.Id,
                    baseAmount, finalAmount);
                return Result<long>.Success(ticketOrder.Id);
            }
        }

        private string ValidateTransportationAndSeats(Transportation? transportation, List<CreateTravellerTicketDto> travelers)
        {
            if (transportation == null) return "Transportation not found";
            if (transportation.StartDateTime <= DateTime.Now) return "Too late to reserve";
            if (transportation.RemainingCapacity < travelers.Count) return "No place";
            return "";
        }

        private async Task AssignSeatsIfDynamic(int vehicleId, List<CreateTravellerTicketDto> travelers)
        {
            var allSeats = await _seatRepository.GetSeatsByVehicleIdAsync(vehicleId);
            var reservedSeats = allSeats.Where(x => x.Tickets.Any(y => y.TicketStatusId == (int) TicketStatusEnum.Reserved));

            if (vehicleId == (int) VehicleTypeEnum.Bus)
            {
                var seatIdsToReserve = travelers.Select(x => x.SeatId ?? 0).ToList();
                if (seatIdsToReserve.Intersect(reservedSeats.Select(x => x.Id)).Any() || seatIdsToReserve.Any(x => x == 0))
                {
                    throw new Exception();
                }
            }
            else
            {
                var freeSeats = allSeats.Where(x => x.Tickets.All(y => y.TicketStatusId != (int) TicketStatusEnum.Reserved)).ToList();
                int i = 0;
                travelers.ForEach(x =>
                {
                    x.SeatId = freeSeats[i].Id;
                    i++;
                });
            }
        }

        private async Task UpsertTravellers(long id, List<CreateTravellerTicketDto> travelers)
        {
            foreach (var traveler in travelers)
            {
                var person = (await _personRepository.FindAsync(p => p.IdNumber == traveler.IdNumber && p.CreatorId == id))
                    .FirstOrDefault();
                if (person != null)
                {
                    traveler.Id = person.Id;
                }

                traveler.CreatorId = id;
                var result = await _personService.UpsertPersonAsync(id, _mapper.Map<PersonDto>(traveler));
                traveler.Id = result.Data;
            }
        }
    }
}
