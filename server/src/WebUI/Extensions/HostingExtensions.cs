using Application;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.CorrespondedUrl.Queries.UrlByAddress;
using Application.CorrespondedUrl.Queries.UrlByAddress.Behaviors;
using Application.LinkShortning.Commands.StandardShortening;
using Application.LinkShortning.Commands.StandardShortening.Behaviors;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebUI.Helpers;

namespace WebUI.Extensions
{
    internal static class HostingExtensions
    {
        internal static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<IAppDbContext, AppDbContext>();
            builder.Services.AddSingleton<IUniqueIdProvider, UniqueIdProvider>();
            builder.Services.AddMediatR(typeof(IApplicationAssemblyReference).Assembly);
            builder.Services.AddScoped<IPipelineBehavior<StandardShorteningCommand, StandardShorteningResult>, StandardShorteningCommandValidationBehavior>();
            builder.Services.AddScoped<IPipelineBehavior<UrlByAddressQuery, UrlByAddressQueryResult>, UrlByAddressQueryValidationBehavior>();
            builder.Services.AddValidatorsFromAssembly(typeof(IApplicationAssemblyReference).Assembly);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(Consts.CORS_POLICY_NAME, policy =>
                {
                    policy.WithOrigins(configuration["CorsSettings:Origin"])
                    .AllowAnyMethod();
                });
            });

            return builder.Build();
        }
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