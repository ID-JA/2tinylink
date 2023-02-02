using Application;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Infrastructure.Persistence;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Application.Common.Behaviors;
using Application.LinkShortning.Commands.RegularShortning;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("Default")));
        builder.Services.AddScoped<IAppDbContext,AppDbContext>();
        builder.Services.AddSingleton<IUniqueIdProvider, UniqueIdProvider>();
        builder.Services.AddMediatR(typeof(IApplicationAssemblyReference).Assembly);
        builder.Services.AddScoped<IPipelineBehavior<RegularShortningCommand, RegularShortningResult>, RegularShortningCommandValidationBehavior>();
        builder.Services.AddValidatorsFromAssembly(typeof(IApplicationAssemblyReference).Assembly);

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseExceptionHandler("/error");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}