using AlibabaClone.Application.DTOs.AccountDTOs;

namespace AlibabaClone.WebAPI.Authentication
{
    public interface IJwtGenerator
    {
        string GenerateToken(AuthResponseDto authResponseDto);
    }
}
