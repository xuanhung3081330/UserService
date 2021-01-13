using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SmallProject.UserService.Application.Commands;
using System.Reflection;

namespace SmallProject.UserService.Application.AIP
{
    public static class MediatorAIP
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateRetailerCommand).GetTypeInfo().Assembly);

            return services;
        }
    }
}
