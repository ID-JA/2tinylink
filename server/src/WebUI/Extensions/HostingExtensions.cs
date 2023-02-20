using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using WebUI.Helpers;

namespace WebUI.Extensions
{
    internal static class HostingExtensions
    {
        internal static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    dbContext.Database.Migrate();

                }
            }

            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseCors(Consts.CORS_POLICY_NAME);

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}