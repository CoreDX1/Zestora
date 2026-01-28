using Microsoft.Extensions.DependencyInjection;
using Zestora.Application.Interfaces;
using Zestora.Application.Services;

namespace Zestora.Application;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
