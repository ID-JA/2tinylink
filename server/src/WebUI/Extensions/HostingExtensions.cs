using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using WebUI.Helpers;
using Application.Extensions;
using Infrastructure.Extensions;

namespace WebUI.Extensions
{
    internal static class HostingExtensions
    {
        internal static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.Services.AddApplicationServices()
                            .AddInfrastructureServices(configuration)
                            .AddPresentationServices(configuration);

          

            return builder.Build();
        }
        
        internal static WebApplication ConfigurePipeline(this WebApplication app)
        {

            app.UseExceptionHandler("/error");

            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    dbContext.Database.Migrate();

                }
            }

            app.UseHttpsRedirection();

            app.UseCors(Consts.CORS_POLICY_NAME);

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers()
                    .RequireAuthorization();
                    

            return app;
        }
    }
}