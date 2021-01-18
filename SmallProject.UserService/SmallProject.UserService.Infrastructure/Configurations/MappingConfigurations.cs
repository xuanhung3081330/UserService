using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SmallProject.UserService.Infrastructure.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Infrastructure.Configurations
{
    public static class MappingConfigurations
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RetailerMappingProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
