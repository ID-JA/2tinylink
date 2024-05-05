using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddAppExeptionMiddleware(this IServiceCollection services) =>
        services.AddScoped<ExceptionMiddleware>();

    public static IApplicationBuilder UseAppExceptionMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<ExceptionMiddleware>();
}
