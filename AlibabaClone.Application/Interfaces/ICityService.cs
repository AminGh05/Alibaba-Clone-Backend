using AlibabaClone.Application.DTOs.CityDTOs;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
	public interface ICityService
	{
		Task<Result<IEnumerable<CityDto>>> GetCitiesAsync();
	}
}
