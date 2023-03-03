using Domain.Entities;

namespace Application.Common.Interfaces.Services
{
    public interface IJwtProvider
    {
        string Create(AppUser appUser);
    }
}