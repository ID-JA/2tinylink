using Application.Common.Interfaces.Services;
using Domain.Entities;
using FluentEmail.Core;

namespace Infrastructure.Mailing;

public class MailService(IFluentEmail fluentEmail) : IMailService
{
    // TODO: Refactor this to be single function SendMail(string template, object model, string email, string? subject)

    private readonly string _templatesPath = Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplates");
    
    public async Task SendAccountConfirmation(AppUser user, string confirmationLink)
    {
        var model = new { FullName = $"{user.FirstName} {user.LastName}", ConfirmationLink = confirmationLink };

        await fluentEmail
            .To(user.Email)
            .Subject("Account Confirmation")
            .UsingTemplateFromFile($"{_templatesPath}/email-confirmation.liquid", model)
            .SendAsync();
    }

    public async Task SendProjectInvitation(string email, string projectName, string invitationLink)
    {
        var model = new { InvitationLink = invitationLink, ProjectName = projectName };

        await fluentEmail
            .To(email)
            .Subject("Project Invitation")
            .UsingTemplateFromFile($"{_templatesPath}/project-invite.liquid", model)
            .SendAsync();
    }
}
