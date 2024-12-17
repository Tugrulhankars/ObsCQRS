using Application.Services.EventStore;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.EventStore;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
    {
        services.AddDbContext<BaseDbContext>(op =>
        {
            op.UseSqlServer("server=MetropolTilkisi;database=ObsCQRS;integrated security=SSPI;persist security info=False;Trusted_Connection=True;Encrypt=false");
        });
        //services.AddIdentityCore<AppUser>()
        //    .AddEntityFrameworkStores<BaseDbContext>();
        

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddTransient<IEventStoreService, EventStoreService>();
        return services;
    }
}
