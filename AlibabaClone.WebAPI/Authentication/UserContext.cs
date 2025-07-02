using AlibabaClone.Application.Interfaces;
using System.Security.Claims;

namespace AlibabaClone.WebAPI.Authentication
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long GetUserId()
        {
            var userIdStr = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (long.TryParse(userIdStr, out var userId))
            {
                return userId;
            }
            throw new InvalidOperationException("User ID is not available or invalid.");
        }
    }
}
