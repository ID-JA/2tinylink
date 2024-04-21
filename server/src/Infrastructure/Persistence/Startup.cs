using Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

public static class Startup
{

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddOptions<DatabaseSettings>()
                .BindConfiguration(nameof(DatabaseSettings))
;

        return services
                   .AddDbContext<AppDbContext>((p, m) =>
                   {
                       var databaseSettings = p.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                       m.UseDatabase(databaseSettings.DBProvider, databaseSettings.ConnectionString);
                   })
                   .AddScoped<IAppDbContext, AppDbContext>();
    }

    internal static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string dbProvider, string connectionString)
    {
        return dbProvider.ToLowerInvariant() switch
        {
            "sqlite" => builder.UseSqlite(connectionString, options => options.MigrationsAssembly("Migrators.SqLite")),
            "sqlserver" => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly("Migrators.MSSQL")),
            _ => throw new InvalidOperationException("the provider not supported")
        };
    }
}


