using AutoMapper;
using MediatR;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using SmallProject.UserService.Infrastructure.EFCore;
using SmallProject.UserService.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dto = SmallProject.UserService.Infrastructure.DTOs;

namespace SmallProject.UserService.Infrastructure.Implementations.Repositories
{
    public class RetailerRepository : IRetailerRepository
    {
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RetailerRepository(UserDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public bool Add(Retailer retailer)
        {
            var mappedRetailer = _mapper.Map<Retailer, Dto.Retailer.Retailer>(retailer);
            _context.Retailers.Add(mappedRetailer);
            //_context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            //var retailer = _context.Retailers.Find(id);
            //// Ko thể thực hiện việc này vì IsDeleted được set là private set
            //// Mục đích để tránh trường hợp bị sai business logic
            ////retailer.IsDeleted = true;

            //_context.SaveChanges();
            //return true;

            throw new NotImplementedException();
        }

        public IEnumerable<Retailer> GetAll()
        {
            var retailerDto = _context.Retailers.Where(x => true);
            var mappedResult = _mapper.Map<IEnumerable<Dto.Retailer.Retailer>, IEnumerable<Retailer>>(retailerDto);
            return mappedResult;
        }

        public Retailer GetById(int id)
        {
            //var result = _context.Retailers.Find(id);
            //return result;
            throw new NotImplementedException();
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch (cử đi) Domain Events collection
            await _mediator.DispatchDomainEventAsync(_context);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers)
            // performed through the DbContext will be committed.
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public bool Update(Retailer retailer, int id)
        {
            // Setting EntityState
            // You can set the EntityState of an entity via the EntityEntry.State property, which is made available
            // by the DbContext.Entry method.

            _context.Entry(retailer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
