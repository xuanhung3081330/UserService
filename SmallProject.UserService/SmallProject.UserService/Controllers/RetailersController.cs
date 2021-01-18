using GraphQL;
using GraphQL.Types;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallProject.UserService.Application.Commands;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using SmallProject.UserService.Extensions;
using SmallProject.UserService.GraphQLCore;
using SmallProject.UserService.GraphQLCore.Retailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallProject.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetailersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDocumentExecuter _documentExecuter;
        private readonly IRetailerRepository _retailerRepo;

        public RetailersController(
            IMediator mediator,
            IDocumentExecuter documentExecuter,
            IRetailerRepository retailerRepo)
        {
            _mediator = mediator;
            _documentExecuter = documentExecuter;
            _retailerRepo = retailerRepo;
        }

        [HttpPost("graphql")]
        public async Task<IActionResult> GraphQLApi([FromBody]GraphQLQuery query)
        {
            // Create inputs. Convert Variables thành kiểu Inputs
            var inputs = query.Variables.ToInputs();

            // Create schema
            var schema = new Schema
            {
                Query = new RetailerQuery(_retailerRepo)
            };

            // Truyền tham số vào hàm ExecuteAsync để thực hiện GraphQL request
            var result = await _documentExecuter.ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                x.OperationName = query.OperationName;
                x.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
