using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmallProject.UserService.Application.EventBus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler { }
}
