using AlibabaClone.Application.DTOs.AuthDTOs;

namespace AlibabaClone.WebAPI.Authentication
{
    public interface IJwtGenerator
    {
        string GenerateToken(AuthResponseDto authResponseDto);
    }
}
