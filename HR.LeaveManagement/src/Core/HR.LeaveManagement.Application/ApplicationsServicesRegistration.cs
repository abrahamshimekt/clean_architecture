using MediatR;
using AutoMapper;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
namespace HR.LeaveManagement.Application{
     public static class ApplicationServicesRegistration{

        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services){
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;

           
        }

    }
}