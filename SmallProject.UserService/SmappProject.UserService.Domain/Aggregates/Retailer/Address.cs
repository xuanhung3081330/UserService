using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Domain.Aggregates.Retailer
{
    public class Address : ValueObject
    {
        public int HouseNum { get; private set; }
        public string Street { get; private set; }
        public string Ward { get; private set; }
        public string District { get; private set; }

        private Address() { }

        public Address(
            int houseNum,
            string street,
            string ward,
            string district)
        {
            HouseNum = houseNum;
            Street = street;
            Ward = ward;
            District = district;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return HouseNum;
            yield return Street;
            yield return Ward;
            yield return District;
        }
    }
}
