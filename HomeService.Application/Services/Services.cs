
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HomeService.Application.Services
{
    public static class Services
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
           
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;

        }
    }
}
