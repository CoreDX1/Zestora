using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zestora.Domain.Core.Repositories;
using Zestora.Infrastructure.Data;
using Zestora.Infrastructure.Repositories;

namespace Zestora.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<PostgresContext>(options =>
                options.UseNpgsql(
                    "name=ConnectionStrings:MyAppDatabase",
                    x => x.MigrationsAssembly("MyApp.Infrastructure")
                )
            );

            services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // services.AddScoped<IEmailService, EmailService>();
            // services.AddScoped<ILoggerService, LoggerService>();
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
}
