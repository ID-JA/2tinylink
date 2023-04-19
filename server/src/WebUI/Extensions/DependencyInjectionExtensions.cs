using WebUI.Helpers;

namespace WebUI.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddControllers();

            // services.AddCors(options =>
            // {
            //   options.AddPolicy(Consts.CORS_POLICY_NAME, policy =>
            //   {
            //       policy.WithOrigins(configuration["CorsSettings:Origin"])
            //             .AllowAnyMethod();
            //   });

            // });
            var corsSettings = configuration.GetSection(nameof(CorsSettings)).Get<CorsSettings>();
            var origins = new List<string>();
            if (corsSettings.Origin is not null)
                origins.AddRange(corsSettings.Origin.Split(';', StringSplitOptions.RemoveEmptyEntries));
            services.AddCors(opt =>
                opt.AddPolicy(Consts.CORS_POLICY_NAME, policy =>
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(origins.ToArray())));

            return services;
        }
    }

    public class CorsSettings
    {
        public string Origin { get; set; }
    }
}