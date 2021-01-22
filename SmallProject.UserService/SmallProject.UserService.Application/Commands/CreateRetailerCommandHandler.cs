using MediatR;
using SmallProject.UserService.Application.EventBus.Abstractions;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmallProject.UserService.Application.Commands
{
    public class CreateRetailerCommandHandler : IRequestHandler<CreateRetailerCommand, bool>
    {
        private readonly IRetailerRepository _retailerRepo;
        private readonly IEventBus _eventBus;

        public CreateRetailerCommandHandler(IRetailerRepository retailerRepo, IEventBus eventBus)
        {
            _retailerRepo = retailerRepo;
            _eventBus = eventBus;
        }

        public async Task<bool> Handle(CreateRetailerCommand request, CancellationToken cancellationToken)
        {
            // Add new Retailer and add AddCreatedRetailerDomainEvent
            Retailer retailer = new Retailer(request.Name, request.Address);
            _retailerRepo.Add(retailer);

            // Publish integration event
            _eventBus.SendRetailer(retailer);

            // Save changes/Save changes async
            return await _retailerRepo.SaveEntitiesAsync(cancellationToken);
        }
    }
}
