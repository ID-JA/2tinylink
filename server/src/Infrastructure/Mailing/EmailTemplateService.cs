using Application.Common.Interfaces.Services;

namespace Infrastructure.Mailing;

internal class EmailTemplateService : IEmailTemplateService
{
    public string GenerateEmailTemplate<T>(string templateName, T model)
    {
        return "X";
    }
}
