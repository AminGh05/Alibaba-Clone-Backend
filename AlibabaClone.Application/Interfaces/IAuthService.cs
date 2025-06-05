using AlibabaClone.Application.DTOs.AccountDTOs;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result<AuthResponseDto>> LoginAsync(LoginRequestDto request);
        Task<Result<AuthResponseDto>> RegisterAsync(RegisterRequestDto request);
    }
}
