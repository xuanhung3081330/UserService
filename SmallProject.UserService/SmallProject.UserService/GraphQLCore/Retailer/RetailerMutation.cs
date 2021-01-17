using GraphQL;
using GraphQL.Types;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using SmallProject.UserService.GraphQLCore.Retailer.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetailerModel = SmallProject.UserService.Domain.Aggregates.Retailer;

namespace SmallProject.UserService.GraphQLCore.Retailer
{
    public class RetailerMutation : ObjectGraphType
    {
        public RetailerMutation(IRetailerRepository retailerRepo)
        {
            Name = "RetailerMutation";

            //Field<RetailerModel.Retailer>(
            //    "updateRetailer",
            //    arguments: new QueryArguments(new QueryArgument<RetailerInputType> { Name = "retailer" }),
            //    resolve: context =>
            //    {
            //        var 
            //    });
        }
    }
}
