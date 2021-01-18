using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Infrastructure.DTOs.Retailer
{
    public class Retailer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HouseNum { get; set; }
        public string Street { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public bool IsDeleted { get; set; }
    }
}
