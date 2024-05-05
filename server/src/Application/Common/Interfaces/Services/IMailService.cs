using Domain.Entities;

namespace Application.Common.Interfaces.Services;

public interface IMailService
{
    public Task SendAccountConfirmation(AppUser user, string confirmationLink);
    public Task SendProjectInvitation(string email, string projectName, string invitationLink);

}
