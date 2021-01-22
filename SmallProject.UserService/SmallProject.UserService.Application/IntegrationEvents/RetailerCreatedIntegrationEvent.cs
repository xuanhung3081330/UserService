using SmallProject.UserService.Application.EventBus;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Application.IntegrationEvents
{
    public class RetailerCreatedIntegrationEvent : IntegrationEvent
    {
        public Retailer Retailer { get; }

        public RetailerCreatedIntegrationEvent(Retailer retailer)
        {
            Retailer = retailer;
        }
    }
}
