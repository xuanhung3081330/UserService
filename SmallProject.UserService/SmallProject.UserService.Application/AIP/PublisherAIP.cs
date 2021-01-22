using Microsoft.Extensions.DependencyInjection;
using SmallProject.UserService.Application.EventBus.Abstractions;
using SmallProject.UserService.Application.EventBus.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Application.AIP
{
    public static class PublisherAIP
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            services.AddTransient<IEventBus, EventBusRabbitMQ>();

            return services;
        }
    }
}
