﻿using AlibabaClone.Application.DTOs.TransportationDTOs;
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

		[HttpPost("search")]
		public async Task<IActionResult> SearchTransportations([FromBody] TransportationSearchRequestDto searchRequest)
		{
			if (searchRequest == null)
			{
				return BadRequest("Invalid search request");
			}

			var result = await _transportationService.SearchTransportationsAsync(searchRequest);
			if (result.IsSuccess)
			{
				return Ok(result.Data);
			}

			// any unsuccessful status
			return result.Status switch
			{
				ResultStatus.NotFound => NotFound(result.ErrorMessage),
				ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
				_ => StatusCode(500, result.ErrorMessage),
			};
		}

		[HttpGet("search/{transportationId}")]
		public async Task<IActionResult> GetTransportation(long transportationId)
		{
			var result = await _transportationService.GetTransportationByIdAsync(transportationId);
			if (result.IsSuccess)
			{
				return Ok(result.Data);
			}

            return result.Status switch
            {
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage),
            };
        }

		[HttpGet("{transportationId}/seats")]
		public async Task<IActionResult> GetTransportationSeats(long transportationId)
		{
			var result = await _transportationService.GetTransportationSeatsAsync(transportationId);
            if (result.IsSuccess)
            {
				return Ok(result.Data);
            }

            return result.Status switch
            {
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }
	}
}
