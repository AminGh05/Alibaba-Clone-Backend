using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.DTOs.TransactionDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    public class AccountController : ControllerBase
    {
        private readonly IUserContext _userContext;
        private readonly IAccountService _accountService;
        private readonly IPersonService _personService;

        public AccountController(IUserContext userContext, IAccountService accountService, IPersonService personService)
        {
            _userContext = userContext;
            _accountService = accountService;
            _personService = personService;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            // get account-id from token
            long userId = _userContext.GetUserId();
            // check for user-id to be valid
            if (userId <= 0)
            {
                return Unauthorized();
            }

            var result = await _accountService.GetProfileAsync(userId);
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

        [HttpPut("email")]
        public async Task<IActionResult> EditEmail([FromBody] EditEmailDto dto)
        {
            var accountId = _userContext.GetUserId();
            if (accountId <= 0)
            {
                return Unauthorized();
            }

            await _accountService.UpdateEmailAsync(accountId, dto.NewEmail);
            return NoContent();
        }

        [HttpPut("password")]
        public async Task<IActionResult> EditPassword([FromBody] EditPasswordDto dto)
        {
            var accountId = _userContext.GetUserId();
            if (accountId <= 0)
            {
                return Unauthorized();
            }

            await _accountService.UpdatePasswordAsync(accountId, dto.OldPassword, dto.NewPassword);
            return NoContent();
        }

        [HttpPost("bank-account-details")]
        public async Task<IActionResult> UpsertBankAccountDetails([FromBody] UpsertBankAccountDto dto)
        {
            var accountId = _userContext.GetUserId();
            if (accountId <= 0)
            {
                return Unauthorized();
            }

            var result = await _accountService.UpsertBankAccountAsync(accountId, dto);
            return result.Status switch
            {
                ResultStatus.Success => NoContent(),
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }

        [HttpGet("people")]
        public async Task<IActionResult> GetPeople()
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0)
            {
                return Unauthorized();
            }

            var result = await _accountService.GetAllPeopleAsync(accountId);
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

        [HttpPost("account-person")]
        public async Task<IActionResult> UpsertAccountPerson([FromBody] PersonDto dto)
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0)
            {
                return Unauthorized();
            }

            var result = await _personService.UpsertAccountPersonAsync(accountId, dto);
            return result.Status switch
            {
                ResultStatus.Success => NoContent(),
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }

        [HttpPost("person")]
        public async Task<IActionResult> UpsertPerson([FromBody] PersonDto dto)
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0)
            {
                return Unauthorized();
            }

            var result = await _personService.UpsertPersonAsync(accountId, dto);
            return result.Status switch
            {
                ResultStatus.Success => NoContent(),
                ResultStatus.Unauthorized => Unauthorized(result.ErrorMessage),
                ResultStatus.NotFound => NotFound(result.ErrorMessage),
                ResultStatus.ValidationError => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }

        [HttpGet("my-travels")]
        public async Task<IActionResult> GetMyTravels()
        {
            long buyerId = _userContext.GetUserId();
            if (buyerId <= 0)
            {
                return Unauthorized();
            }

            var result =  await _accountService.GetTravelsAsync(buyerId);
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

        [HttpGet("my-transactions")]
        public async Task<IActionResult> GetMyTransactions()
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0)
            {
                return Unauthorized();
            }

            var result = await _accountService.GetTransactionsAsync(accountId);
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

        [HttpPost("top-up")]
        public async Task<IActionResult> TopUpAccount(TopUpDto dto)
        {
            if (dto.Amount <= 0)
            {
                return BadRequest("Amount should be positive");
            }

            long accountId = _userContext.GetUserId();
            if (accountId <= 0)
            {
                return Unauthorized();
            }

            var result = await _accountService.TopUpAsync(accountId, dto);
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

        [HttpGet("my-travels/{ticketOrderId}")]
        public async Task<IActionResult> GetTravelDetails(long ticketOrderId)
        {
            long accountId = _userContext.GetUserId();
            if (accountId <= 0)
            {
                return Unauthorized();
            }

            var result = await _accountService.GetTicketOrderDetailsAsync(accountId, ticketOrderId);
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
