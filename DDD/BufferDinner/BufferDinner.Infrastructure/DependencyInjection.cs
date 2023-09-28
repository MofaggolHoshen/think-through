
using BufferDinner.Application.Common.Interfaces.Authentication;
using BufferDinner.Application.Common.Interfaces.Services;
using BufferDinner.Infrastructure.Authentication;
using BufferDinner.Infrastructure.Sevices;
using Microsoft.Extensions.DependencyInjection;

namespace BufferDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        // Add DateTimeProvider
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}


