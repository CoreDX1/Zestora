using Microsoft.Extensions.DependencyInjection;
using Zestora.Application.Interfaces;
using Zestora.Application.Security;
using Zestora.Application.Services;

namespace Zestora.Application;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceExtensions).Assembly);

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
