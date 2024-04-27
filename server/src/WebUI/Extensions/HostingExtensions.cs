using Application;
using Application.UseCases.Auth.Commands.Register;
using Application.UseCases.Auth.Commands.Register.Behaviors;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.UseCases.Auth.Queries.Login;
using Application.UseCases.Auth.Queries.Login.Behaviors;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Options;
using Application.Common.Interfaces;
using Domain.Entities.Common;
using Infrastructure.Repository;
using Infrastructure.Mailing;

namespace WebUI.Extensions
{
    internal static class HostingExtensions
    {
        private const string CorsPolicy = nameof(Consts.CORS_POLICY_NAME);
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Add Repositories
            services.AddScoped(typeof(IRepository<>), typeof(ApplicationDbRepository<>));

            foreach (var aggregateRootType in
                     typeof(IAggregateRoot).Assembly.GetExportedTypes()
                         .Where(t => typeof(IAggregateRoot).IsAssignableFrom(t) && t.IsClass)
                         .ToList())
            {
                // Add ReadRepositories.
                services.AddScoped(typeof(IReadRepository<>).MakeGenericType(aggregateRootType), sp =>
                    sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(aggregateRootType)));

            }

            return services;
        }
        internal static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.Services.AddControllers();
            builder.Services.AddPersistence();
            // Add Options
            builder.Services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.JWT));


            // Add JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
            {
                var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>();

                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.SigningKey)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience

                };
            });

            builder.Services.AddIdentityCore<AppUser>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.SignIn.RequireConfirmedEmail = true;
            })
            .AddSignInManager<SignInManager<AppUser>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IUniqueIdProvider, UniqueIdProvider>();
            builder.Services.AddScoped<IJwtProvider, JwtProvider>();
            builder.Services.AddScoped<CurrentUserMiddleware>().
               AddScoped<ICurrentUser, CurrentUser>();

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IApplicationAssemblyReference).Assembly);

            });
            
            builder.Services.AddMailing();
            builder.Services.AddScoped<IMailService, MailService>();

            builder.Services.AddScoped<IPipelineBehavior<StandardShorteningCommand, StandardShorteningResult>, StandardShorteningCommandValidationBehavior>();
            builder.Services.AddScoped<IPipelineBehavior<UrlByAddressQuery, UrlByAddressQueryResult>, UrlByAddressQueryValidationBehavior>();
            builder.Services.AddScoped<IPipelineBehavior<RegisterCommand, RegisterCommandResult>, RegisterCommandValidationBehavior>();
            builder.Services.AddScoped<IPipelineBehavior<UserByUserNameQuery, UserByUserNameQueryResult>, UserByUserNameQueryValidationBehavior>();
            builder.Services.AddScoped<IPipelineBehavior<LoginQuery, LoginQueryResult>, LoginQueryValidationBehavior>();
            builder.Services.AddValidatorsFromAssembly(typeof(IApplicationAssemblyReference).Assembly);
            builder.Services.AddRepositories();
            builder.Services.AddCors(opt =>
                opt.AddPolicy(CorsPolicy, policy =>
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("https://localhost:3000", "http://localhost:3000")));


            return builder.Build();
        }
        internal static WebApplication ConfigurePipeline(this WebApplication app)
        {

            app.UseExceptionHandler("/error");

            if (app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                //dbContext.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CorsPolicy);

            app.UseAuthentication();

            app.UseMiddleware<CurrentUserMiddleware>();

            app.UseAuthorization();


            app.MapControllers()
                    .RequireAuthorization();


            return app;
        }
    }
}