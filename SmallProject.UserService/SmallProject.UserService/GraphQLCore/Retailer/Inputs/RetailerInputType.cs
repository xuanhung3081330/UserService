using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetailerModel = SmallProject.UserService.Domain.Aggregates.Retailer;

namespace SmallProject.UserService.GraphQLCore.Retailer.Inputs
{
    public class RetailerInputType : InputObjectGraphType<RetailerModel.Retailer>
    {
        public RetailerInputType()
        {
            Name = "RetailerInput";

            Field(x => x.Name.FirstName).Description("First name of the retailer");
            Field(x => x.Name.LastName).Description("Last name of the retailer");
            Field(x => x.Address.District).Description("District of the retailer");
            Field(x => x.Address.HouseNum).Description("HouseNum of the retailer");
            Field(x => x.Address.Street).Description("Street of the retailer");
            Field(x => x.Address.Ward).Description("Ward of the retailer");
        }
    }
}
