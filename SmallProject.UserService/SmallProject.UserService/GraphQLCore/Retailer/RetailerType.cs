using GraphQL.Types;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetailerModel = SmallProject.UserService.Domain.Aggregates.Retailer;

namespace SmallProject.UserService.GraphQLCore.Retailer
{
    public class RetailerType : ObjectGraphType<RetailerModel.Retailer>
    {
        public RetailerType()
        {
            Field(x => x.Id).Description("Retailer id.");
            Field(x => x.Name.FirstName).Description("First name.");
            Field(x => x.Name.LastName).Description("Last name.");
            Field(x => x.Address.Street).Description("Street.");
            Field(x => x.Address.HouseNum).Description("House Num.");
            Field(x => x.Address.District).Description("District.");
            Field(x => x.Address.Ward).Description("Ward.");
        }
    }
}
