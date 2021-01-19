using MediatR;
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

        public CreateRetailerCommandHandler(IRetailerRepository retailerRepo)
        {
            _retailerRepo = retailerRepo;
        }

        public async Task<bool> Handle(CreateRetailerCommand request, CancellationToken cancellationToken)
        {
            // Add new Retailer and add AddCreatedRetailerDomainEvent
            Retailer retailer = new Retailer(request.Name, request.Address);
            _retailerRepo.Add(retailer);

            return await _retailerRepo.SaveEntitiesAsync(cancellationToken);
        }
    }
}
