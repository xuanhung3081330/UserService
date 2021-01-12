using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Infrastructure.DTOs.Retailer
{
    public class Retailer
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
    }
}
