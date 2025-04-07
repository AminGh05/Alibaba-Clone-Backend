using AlibabaClone.Application.DTOs.TransportationDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TransportationController : ControllerBase
	{
		private readonly ITransportationService _transportationService;

		public TransportationController(ITransportationService transportationService)
		{
			_transportationService = transportationService;
		}

		[HttpGet("search")]
		public async Task<IActionResult> SearchTransportations([FromBody] TransportationSearchRequestDto searchRequest)
		{
			if (searchRequest == null)
			{
				return BadRequest("Invalid search request");
			}

			var result = await _transportationService.SearchTransportationsAsync(searchRequest);
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
