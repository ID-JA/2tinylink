using Application;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Infrastructure.Persistence;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Application.LinkShortning.Commands.StandardShortening;
using Application.LinkShortning.Commands.StandardShortening.Behaviors;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("Default")));
        builder.Services.AddScoped<IAppDbContext, AppDbContext>();
        builder.Services.AddSingleton<IUniqueIdProvider, UniqueIdProvider>();
        builder.Services.AddMediatR(typeof(IApplicationAssemblyReference).Assembly);
        builder.Services.AddScoped<IPipelineBehavior<StandardShorteningCommand, StandardShorteningResult>, StandardShorteningCommandValidationBehavior>();
        builder.Services.AddValidatorsFromAssembly(typeof(IApplicationAssemblyReference).Assembly);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("2tinylinkApp", policy =>
            {
                policy.WithOrigins(configuration["CorsSettings:Origin"])
                .AllowAnyMethod();
            });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();

            }
        }


        // Configure the HTTP request pipeline.

        app.UseExceptionHandler("/error");

        app.UseHttpsRedirection();

        app.UseCors("2tinylinkApp");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}