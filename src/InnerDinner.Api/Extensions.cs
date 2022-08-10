using InnerDinner.Api.Common.Mappings;
using InnerDinner.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace InnerDinner.Api;

public static class Extensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, InnerDinnerProblemDetailsFactory>();
        services.AddMapping();

        return services;
    }
}