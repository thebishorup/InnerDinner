using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InnerDinner.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Extensions).Assembly);
        return services;
    }
}