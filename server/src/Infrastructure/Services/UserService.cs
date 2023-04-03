using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using WebUI.Application.Common.Interfaces.Services;

namespace WebUI.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            var id = string.Empty;

            if(_httpContextAccessor.HttpContext is not null)
            {
                id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            
            return id;
        }
    }
}