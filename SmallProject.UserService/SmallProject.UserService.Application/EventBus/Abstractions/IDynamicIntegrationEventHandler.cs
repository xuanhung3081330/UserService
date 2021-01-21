using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmallProject.UserService.Application.EventBus.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
