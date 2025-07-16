using AlibabaClone.Application.DTOs.TransportationDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    public class TicketOrderController : ControllerBase
    {
        private readonly IUserContext _userContext;
        private readonly ITicketOrderService _ticketOrderService;

        public TicketOrderController(IUserContext userContext,
            ITicketOrderService ticketOrderService)
        {
            _userContext = userContext;
            _ticketOrderService = ticketOrderService;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateTicketOrder([FromBody] CreateTicketOrderDto dto)
        {
            long accountId = _userContext.GetUserId();
            // check for account-id to be valid
            if (accountId <= 0)
            {
                return Unauthorized();
            }

            var result = await _ticketOrderService.CreateTicketOrderAsync(accountId, dto);
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
