namespace Infrastructure.Identity;

using Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


public static class DependencyInjection
{
    public static IServiceCollection AddInfraIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Jwt>(configuration.GetSection("JWT"));

        return services;
    }
}
