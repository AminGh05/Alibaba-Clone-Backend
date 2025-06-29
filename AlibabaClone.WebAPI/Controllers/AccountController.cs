using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserContext _userContext;
        private readonly IAccountService _accountService;

        public AccountController(IUserContext userContext, IAccountService accountService)
        {
            _userContext = userContext;
            _accountService = accountService;
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
    }
}
