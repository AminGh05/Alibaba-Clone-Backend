using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CityController : ControllerBase
	{
		private readonly ICityService _cityService;

		public CityController(ICityService cityService)
		{
			_cityService = cityService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCities()
		{
			var result = await _cityService.GetCitiesAsync();
			if (result.IsSuccess)
			{
				return Ok(result);
			}

			// any unsuccessful status
			switch (result.Status)
			{
				case ResultStatus.NotFound:
					return NotFound(result.ErrorMessage);
				case ResultStatus.ValidationError:
					return BadRequest(result.ErrorMessage);
				default:
					return StatusCode(500, result.ErrorMessage);
			}
		}
	}
}
