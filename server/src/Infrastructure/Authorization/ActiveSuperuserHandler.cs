using System.Security.Claims;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Authorization
{
    public class ActiveSuperuserOnlyHandler : AuthorizationHandler<ActiveSuperuserOnlyRequirement>
    {
        private readonly UserManager<AppUser> _userManager;

        public ActiveSuperuserOnlyHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ActiveSuperuserOnlyRequirement requirement)
        {
            var userId = context.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                context.Fail();
                return;
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user != null && user.IsActive && await _userManager.IsInRoleAsync(user, "Superuser"))
            {
                context.Succeed(requirement);
                return;
            }
            else
            {
                context.Fail();
                return;
            }
        }
    }
}