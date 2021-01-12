using Microsoft.Extensions.DependencyInjection;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using SmallProject.UserService.Infrastructure.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Infrastructure.AIP
{
    public static class RepositoryAIP
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            services.AddTransient<IRetailerRepository, RetailerRepository>();

            return services;
        }
    }
}
