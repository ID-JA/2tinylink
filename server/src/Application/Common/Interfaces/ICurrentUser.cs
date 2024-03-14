using System.Security.Claims;

namespace Application.Common.Interfaces;

public interface ICurrentUser
{
    string? Name { get; }

    string GetUserId();

    string GetUserEmail();

    bool IsAuthenticated();
    void SetCurrentUser(ClaimsPrincipal user);

    void SetCurrentUserId(string userId);

    IEnumerable<Claim>? GetUserClaims();

}
