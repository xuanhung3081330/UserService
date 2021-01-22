using MediatR;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using SmallProject.UserService.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmallProject.UserService.Application.DomainEventHandlers
{
    public class RetailerCreatedDomainEventHandler : INotificationHandler<RetailerCreatedDomainEvent>
    {
        private readonly IRetailerRepository _retailerRepo;

        public RetailerCreatedDomainEventHandler(IRetailerRepository retailerRepo)
        {
            _retailerRepo = retailerRepo;
        }

        public async Task Handle(RetailerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
