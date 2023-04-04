using System.Text;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using Infrastructure.Options;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebUI.Application.Common.Interfaces.Services;
using WebUI.Infrastructure.Services;

namespace Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("Default")));
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<AppDbContextInitializer>();

            services.AddScoped<IUserService, UserService>();

            // Add Options
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.JWT));


            // Add JWT Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
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

            services.AddIdentityCore<AppUser>(opts =>
            {
                opts.User.RequireUniqueEmail      = true;
                opts.SignIn.RequireConfirmedEmail = true;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
            .AddSignInManager<SignInManager<AppUser>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


            services.AddSingleton<IUniqueIdProvider, UniqueIdProvider>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            return services;
        }
    }
}