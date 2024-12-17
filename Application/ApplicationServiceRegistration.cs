using Application.Pipelines.Authorization;
using Application.Pipelines.Caching;
using Application.Security.JWT;
using Application.Tools.Constants;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<OpenTelemetryConstants>(configuration.GetSection("OpenTelemetry"));
        var openTelemetryConstants = configuration.GetSection("OpenTelemetry").Get<OpenTelemetryConstants>();

        services.AddOpenTelemetry().WithTracing(options =>
        {
            options
           .AddSource(openTelemetryConstants.ActivitySourceName)
           .ConfigureResource(resource =>
           {
               resource.AddService(openTelemetryConstants.ServiceName,serviceVersion: openTelemetryConstants.ServiceVersion);
           });

            options.AddAspNetCoreInstrumentation(aspOptions =>
            {
                aspOptions.Filter = (context) =>
                {
                    return context.Request.Path.Value.Contains("api", StringComparison.InvariantCulture);
                };
            });

            options.AddOtlpExporter();
            
        }
           

        );

        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //services.AddTransient(typeof(IPipelineBehavior<,>),typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(AuthorizationBehavior<,>));
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            
        });


        return services;
    }
}
