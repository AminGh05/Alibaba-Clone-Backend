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
        private readonly ITicketOrderRepository _ticketOrderRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransportationLockService _transportationLockService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TicketOrderService(IAccountRepository accountRepository,
            ITransportationRepository transportationRepository,
            ISeatRepository seatRepository,
            ITicketOrderRepository ticketOrderRepository,
            ITicketRepository ticketRepository,
            ITransportationLockService transportationLockService,
            IAccountService accountService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _transportationRepository = transportationRepository;
            _seatRepository = seatRepository;
            _ticketOrderRepository = ticketOrderRepository;
            _ticketRepository = ticketRepository;
            _transportationLockService = transportationLockService;
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
                return Result<long>.Error("Account not found");
            }

            // get the transportation
            var transportation = await _transportationRepository.GetByIdAsync(dto.TransportationId);
            if (transportation == null)
            {
                return Result<long>.Error("Transportation not found");
            }

            // lock the transportation through reservation
            using (await _transportationLockService.AcquireLockAsync(dto.TransportationId))
            {
                var baseAmount = transportation.BasePrice * dto.Travellers.Count;
                if (account.Balance < baseAmount)
                {
                    return Result<long>.Error("Not enough money");
                }
                // check validity of transportation
                var checkSeats = ValidateTransportationAndSeats(transportation, dto.Travellers);
                if (!string.IsNullOrEmpty(checkSeats))
                {
                    return Result<long>.Error(checkSeats);
                }

                var finalAmount = baseAmount;
                await AssignSeats(transportation.VehicleId, dto.Travellers);

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
                        return Result<long>.Error("Seat ID is required for each traveller");
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

        private async Task AssignSeats(int vehicleId, List<CreateTravellerTicketDto> travelers)
        {
            var allSeats = await _seatRepository.GetSeatsByVehicleIdAsync(vehicleId);
            var freeSeats = allSeats.Where(x => x.Tickets.All(y => y.TicketStatusId != (int)TicketStatusEnum.Reserved)).ToList();
            int i = 0;
            travelers.ForEach(x =>
            {
                x.SeatId = freeSeats[i].Id;
                i++;
            });
        }
    }
}
