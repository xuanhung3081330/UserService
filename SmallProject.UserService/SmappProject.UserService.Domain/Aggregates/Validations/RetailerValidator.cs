using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Domain.Aggregates.Validations
{
    public class RetailerValidator : AbstractValidator<Retailer.Retailer>
    {
        public RetailerValidator()
        {
            
        }
    }
}
