using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zestora.Domain.Core.Repositories;
using Zestora.Infrastructure.Data;
using Zestora.Infrastructure.Repositories;

namespace Zestora.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<PostgresContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("Zestora.Infrastructure")
            )
        );

        services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        // services.AddScoped<ILoggerService, LoggerService>();

        return services;
    }

    public static void MigrateDatabase(this IServiceProvider serviceProvider)
    {
        var dbContextOptions = serviceProvider.GetRequiredService<
            DbContextOptions<PostgresContext>
        >();

        using (var dbContext = new PostgresContext(dbContextOptions))
        {
            dbContext.Database.Migrate();
        }
    }
}
