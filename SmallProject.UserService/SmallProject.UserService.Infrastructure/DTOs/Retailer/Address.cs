using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Infrastructure.DTOs.Retailer
{
    public class Address
    {
        public int HouseNum { get; set; }
        public string Street { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
    }
}
