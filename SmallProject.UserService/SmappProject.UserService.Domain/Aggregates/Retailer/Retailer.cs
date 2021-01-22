using SmallProject.UserService.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Domain.Aggregates.Retailer
{
    public class Retailer : Entity, IAggregateRoot
    {
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public bool IsDeleted { get; private set; }

        private Retailer() { }

        public Retailer(Name name, Address address)
        {
            Name = name;
            Address = address;
            IsDeleted = false;

            // Add the RetailerCreatedDomainEvent to the domain events collection
            // to be raised/dispatched when committing changes into the database (After DbContext.SaveChanges())
            AddCreatedRetailerDomainEvent(name, address);
        }

        private void AddCreatedRetailerDomainEvent(Name name, Address address)
        {
            var retailerCreatedDomainEvent = new RetailerCreatedDomainEvent(this, name, address);

            this.AddDomainEvent(retailerCreatedDomainEvent);
        }
    }
}
