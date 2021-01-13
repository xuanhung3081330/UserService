using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SmallProject.UserService.Domain.Aggregates.Retailer;

namespace SmallProject.UserService.Application.Commands
{
    public class CreateRetailerCommand : IRequest<bool>
    {
        public Name Name { get; set; }
        public Address Address { get; set; }
    }
}
