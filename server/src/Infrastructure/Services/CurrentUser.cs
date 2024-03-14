using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Services;

public class CurrentUser : ICurrentUser
{

    private ClaimsPrincipal? _user;

    private string _userId = string.Empty;

    string ICurrentUser.Name => _user.Identity?.Name;

    public IEnumerable<Claim> GetUserClaims() => _user?.Claims;

    public string GetUserEmail() => IsAuthenticated() 
        ? _user.FindFirstValue(ClaimTypes.Email) 
        : string.Empty;

    public string GetUserId() => IsAuthenticated()
            ? _user.FindFirstValue(ClaimTypes.NameIdentifier)
            : _userId;

    public bool IsAuthenticated() => _user?.Identity.IsAuthenticated is true;

    public void SetCurrentUser(ClaimsPrincipal user)
    {
        if (_user != null)
        {
            throw new Exception("Method reserved for in-scope initialization");
        }

        _user = user;
    }

    public void SetCurrentUserId(string userId)
    {
        if (_userId != string.Empty)
        {
            throw new Exception("Method reserved for in-scope initialization");
        }

        if (!string.IsNullOrEmpty(userId))
        {
            _userId = userId;
        }
    }

}
