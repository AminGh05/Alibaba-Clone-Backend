using AlibabaClone.Application.DTOs.TransportationDTOs;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
	public interface ITransportationService
	{
		Task<Result<IEnumerable<TransportationSearchResultDto>>> SearchTransportationsAsync(TransportationSearchRequestDto requestDto);
	}
}
