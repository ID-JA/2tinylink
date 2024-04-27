using Domain.Entities;

namespace Application.Common.Interfaces.Services;

public interface IMailService
{
    public Task SendAccountConfirmation(AppUser user, string confirmationLink);
}
