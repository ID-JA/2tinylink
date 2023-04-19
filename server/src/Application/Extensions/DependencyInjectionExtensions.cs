using Application.UseCases._Common;
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
            services.AddValidatorsFromAssembly(typeof(IApplicationAssemblyReference).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}