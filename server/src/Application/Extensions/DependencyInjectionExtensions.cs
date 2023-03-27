using Application.UseCases.Auth.Commands.Register;
using Application.UseCases.Auth.Commands.Register.Behaviors;
using Application.UseCases.Auth.Queries.Login;
using Application.UseCases.Auth.Queries.Login.Behaviors;
using Application.UseCases.CorrespondedUrl.Queries.UrlByAlias;
using Application.UseCases.CorrespondedUrl.Queries.UrlByAlias.Behaviors;
using Application.UseCases.LinkShortening.Commands.StandardShortening;
using Application.UseCases.LinkShortening.Commands.StandardShortening.Behaviors;
using Application.UseCases.UserManagement.Queries.UserByUserName;
using Application.UseCases.UserManagement.Queries.UserByUserName.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IApplicationAssemblyReference).Assembly);
            services.AddScoped<IPipelineBehavior<StandardShorteningCommand, StandardShorteningResult>, StandardShorteningCommandValidationBehavior>();
            services.AddScoped<IPipelineBehavior<UrlByAliasQuery, UrlByAliasQueryResult>, UrlByAliasQueryValidationBehavior>();
            services.AddScoped<IPipelineBehavior<RegisterCommand, RegisterCommandResult>, RegisterCommandValidationBehavior>();
            services.AddScoped<IPipelineBehavior<UserByUserNameQuery, UserByUserNameQueryResult>, UserByUserNameQueryValidationBehavior>();
            services.AddScoped<IPipelineBehavior<LoginQuery, LoginQueryResult>, LoginQueryValidationBehavior>();
            services.AddValidatorsFromAssembly(typeof(IApplicationAssemblyReference).Assembly);

            return services;
        }
    }
}