using Application;
using Application.UseCases.Auth.Command.Register;
using Application.UseCases.Auth.Command.Register.Behaviors;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.UseCases.CorrespondedUrl.Queries.UrlByAddress;
using Application.UseCases.CorrespondedUrl.Queries.UrlByAddress.Behaviors;
using Application.UseCases.LinkShortening.Commands.StandardShortening;
using Application.UseCases.LinkShortening.Commands.StandardShortening.Behaviors;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebUI.Helpers;
using Application.UseCases.UserManagement.Queries.UserByUserName;
using Application.UseCases.UserManagement.Queries.UserByUserName.Behaviors;

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

            builder.Services.AddIdentityCore<AppUser>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddSingleton<IUniqueIdProvider, UniqueIdProvider>();

            builder.Services.AddMediatR(typeof(IApplicationAssemblyReference).Assembly);

            builder.Services.AddScoped<IPipelineBehavior<StandardShorteningCommand, StandardShorteningResult>, StandardShorteningCommandValidationBehavior>();
            builder.Services.AddScoped<IPipelineBehavior<UrlByAddressQuery, UrlByAddressQueryResult>, UrlByAddressQueryValidationBehavior>();
            builder.Services.AddScoped<IPipelineBehavior<RegisterCommand, RegisterCommandResult>, RegisterCommandValidationBehavior>();
            builder.Services.AddScoped<IPipelineBehavior<UserByUserNameQuery, UserByUserNameQueryResult>, UserByUserNameQueryValidationBehavior>();
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

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}