using GraphQL;
using GraphQL.Types;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallProject.UserService.GraphQLCore.Retailer
{
    public class RetailerQuery : ObjectGraphType
    {
        public RetailerQuery(IRetailerRepository retailerRepo)
        {
            Name = "RetailerQuery";

            Field<RetailerType>(
                "retailer",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "retailerId" }),
                resolve: context => retailerRepo.GetById(context.GetArgument<int>("retailerId")));

            Field<ListGraphType<RetailerType>>(
                "retailers",
                resolve: context => retailerRepo.GetAll());
        }
    }
}
