using FluentEmail.MailKitSmtp;
using MailKit.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Infrastructure.Mailing;

public static class Startup
{
    public static IServiceCollection AddMailing(this IServiceCollection services)
    {
        string baseDirectory = Directory.GetCurrentDirectory();

        services.AddFluentEmail("amir.hackett@ethereal.email")
            .AddLiquidRenderer()
            .AddMailKitSender(new SmtpClientOptions
            {
                Server = "smtp.ethereal.email",
                Port = 587,
                User = "amir.hackett@ethereal.email",
                Password = "7FHpUSKuCwBuzS24rk",
                RequiresAuthentication = true,
                SocketOptions = SecureSocketOptions.StartTls
            });

        return services;
    }
}