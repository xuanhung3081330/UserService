using Autofac;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmallProject.UserService.Application.DomainEventHandlers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SmallProject.UserService.Application.AIP
{
    public class DomainEventHandlerAIP : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register the DomainEventHandler classes (they implement IAsyncNotificationHandler<>)
            // in assembly holding the Domain Events.
            builder.RegisterAssemblyTypes(typeof(RetailerCreatedDomainEventHandler).GetTypeInfo()
                .Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));
        }
    }
}
