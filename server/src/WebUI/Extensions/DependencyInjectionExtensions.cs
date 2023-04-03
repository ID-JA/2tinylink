using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebUI.Errors;
using WebUI.Helpers;

namespace WebUI.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddControllers();

            services.AddSingleton<ProblemDetailsFactory, AppProblemDetailsFactory>();

            services.AddCors(options =>
            {
              options.AddPolicy(Consts.CORS_POLICY_NAME, policy =>
              {
                  policy.WithOrigins(configuration["CorsSettings:Origin"])
                        .AllowAnyMethod();
              });

            });


            return services;
        }
    }
}