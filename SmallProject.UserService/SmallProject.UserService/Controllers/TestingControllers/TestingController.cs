using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using SmallProject.UserService.Extensions;
using SmallProject.UserService.GraphQLCore;
using SmallProject.UserService.GraphQLCore.Retailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallProject.UserService.Controllers.TestingControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private readonly IRetailerRepository _retailerRepo;
        private readonly IDocumentExecuter _documentExecuter;

        public TestingController(IRetailerRepository retailerRepo, IDocumentExecuter documentExecuter)
        {
            _retailerRepo = retailerRepo;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> TestingGet([FromBody]GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new RetailerQuery(_retailerRepo)
            };

            var result = await _documentExecuter.ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
