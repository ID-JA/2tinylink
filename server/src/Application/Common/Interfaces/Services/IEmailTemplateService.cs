namespace Application.Common.Interfaces.Services;

public interface IEmailTemplateService
{
    string GenerateEmailTemplate<T>(string templateName, T model);
}
