using HomeService.Application.Repository;
using HomeService.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Infrastructure.Extension
{
    public static class InfrasExtensions
    {
        public static IServiceCollection AddRepositories( this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
