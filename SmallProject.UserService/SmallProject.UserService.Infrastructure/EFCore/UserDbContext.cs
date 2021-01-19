using MediatR;
using Microsoft.EntityFrameworkCore;
using SmallProject.UserService.Domain.Aggregates;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using SmallProject.UserService.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dto = SmallProject.UserService.Infrastructure.DTOs;

namespace SmallProject.UserService.Infrastructure.EFCore
{
    public class UserDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Dto.Retailer.Retailer> Retailers { get; set; }

        private readonly IMediator _mediator;

        public UserDbContext(DbContextOptions<UserDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        //public UserDbContext()
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseMySQL("Server=localhost;Database=smallproj.user;Uid=root;Pwd=1234");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Retailer
            modelBuilder.ApplyConfiguration(new RetailerEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection.
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions.
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers.
            await _mediator.DispatchDomainEventAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handler)
            // performed through the DbContext will be committed
            await base.SaveChangesAsync(cancellationToken);
            
            return true;
        }
    }
}
