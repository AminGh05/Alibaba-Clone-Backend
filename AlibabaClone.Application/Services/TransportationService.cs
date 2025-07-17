using AlibabaClone.Application.DTOs.TransportationDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class TransportationService : ITransportationService
    {
        private readonly ITransportationRepository _transportationRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransportationService(ITransportationRepository transportationRepository,
            ISeatRepository seatRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _transportationRepository = transportationRepository;
            _seatRepository = seatRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<TransportationSearchResultDto>> GetTransportationByIdAsync(long transportationId)
        {
            var transportation = await _transportationRepository.GetByIdAsync(transportationId);
            if (transportation == null)
            {
                return Result<TransportationSearchResultDto>.NotFound();
            }

            return Result<TransportationSearchResultDto>.Success(_mapper.Map<TransportationSearchResultDto>(transportation));
        }

        public async Task<Result<List<TransportationSeatDto>>> GetTransportationSeatsAsync(long transportationId)
        {
            var transportation = await _transportationRepository.GetByIdAsync(transportationId);
            if (transportation == null)
            {
                return Result<List<TransportationSeatDto>>.Error("Transportation not found");
            }

            var seats = await _seatRepository.GetSeatsByVehicleIdAsync(transportation.VehicleId);
            if (seats == null || seats.Count != 0)
            {
                return Result<List<TransportationSeatDto>>.Success(_mapper.Map<List<TransportationSeatDto>>(seats));
            }

            return Result<List<TransportationSeatDto>>.NotFound();
        }

        public async Task<Result<IEnumerable<TransportationSearchResultDto>>> SearchTransportationsAsync(TransportationSearchRequestDto requestDto)
        {
            var result = await _transportationRepository.SearchTransportationsAsync(
                vehicleTypeId: requestDto.VehicleTypeId,
                fromCityId: requestDto.FromCityId,
                toCityId: requestDto.ToCityId,
                startDateTime: requestDto.StartDate,
                endDateTime: requestDto.EndDate,
                remainingCapacity: requestDto.PassengerCount);

            if (result.Any())
            {
                var dto = _mapper.Map<IEnumerable<TransportationSearchResultDto>>(result);
                return Result<IEnumerable<TransportationSearchResultDto>>.Success(dto);
            }

            return Result<IEnumerable<TransportationSearchResultDto>>.NotFound();
        }
    }
}
