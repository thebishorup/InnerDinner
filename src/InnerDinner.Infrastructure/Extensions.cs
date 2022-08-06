using InnerDinner.Application.Common.Interfaces.Authentication;
using InnerDinner.Application.Common.Interfaces.Persistance;
using InnerDinner.Application.Common.Services;
using InnerDinner.Infrastructure.Authentication;
using InnerDinner.Infrastructure.Persistance;
using InnerDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnerDinner.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}