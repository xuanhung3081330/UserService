using MediatR;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Domain.Events
{
    public class RetailerCreatedDomainEvent : INotification
    {
        public Name Name { get; }
        public Address Address { get; }
        public Retailer Retailer { get; }

        public RetailerCreatedDomainEvent(Retailer retailer, Name name, Address address)
        {
            Retailer = retailer;
            Name = name;
            Address = address;
        }
    }
}
