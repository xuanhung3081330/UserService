using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Domain.Aggregates.Retailer
{
    public class Retailer : Entity, IAggregateRoot
    {
        public Name Name { get; private set; }
        public Address Address { get; private set; }

        public Retailer(Name name, Address address)
        {
            Name = name;
            Address = address;
        }
    }
}
