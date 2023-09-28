using BufferDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BufferDinner.Application;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            //services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
