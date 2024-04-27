using Application.Common.Interfaces.Services;
using Domain.Entities;
using FluentEmail.Core;

namespace Infrastructure.Mailing;

public class MailService(IFluentEmail fluentEmail) : IMailService
{

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
}
