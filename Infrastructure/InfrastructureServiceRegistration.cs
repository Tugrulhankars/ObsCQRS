using Amazon.SimpleEmail;
using Infrastructure.Aws.Ses;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        // services.AddScoped<IRedisService, RedisService>();

        services.AddDefaultAWSOptions(configuration.GetAWSOptions());
        services.AddAWSService<IAmazonSimpleEmailService>();
        services.AddSingleton<ISesService, SesService>();
        return services;
           

    }
}
