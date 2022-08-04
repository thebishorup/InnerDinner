using InnerDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace InnerDinner.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}