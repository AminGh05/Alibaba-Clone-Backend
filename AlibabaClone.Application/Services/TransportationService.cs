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
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public TransportationService(ITransportationRepository transportationRepository, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_transportationRepository = transportationRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<Result<IEnumerable<TransportationSearchResultDto>>> SearchTransportationsAsync(TransportationSearchRequestDto requestDto)
		{
			var result = await _transportationRepository.SearchTransportationsAsync(
				fromCityId: requestDto.FromCityId,
				toCityId: requestDto.ToCityId,
				startDateTime: requestDto.StartDate,
				endDateTime: requestDto.EndDate);

			if (result.Any())
			{
				var dto = _mapper.Map<IEnumerable<TransportationSearchResultDto>>(result);
				return Result<IEnumerable<TransportationSearchResultDto>>.Success(dto);
			}

			return Result<IEnumerable<TransportationSearchResultDto>>.NotFound(null);
		}
	}
}
