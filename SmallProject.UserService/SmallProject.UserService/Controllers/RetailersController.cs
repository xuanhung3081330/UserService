using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallProject.UserService.Domain.Aggregates.Retailer;
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
        private readonly IRetailerRepository _retailerRepo;

        public RetailersController(IRetailerRepository retailerRepo)
        {
            _retailerRepo = retailerRepo;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Retailer retailer)
        {
            _retailerRepo.Add(retailer);
            return Ok();
        }
    }
}
