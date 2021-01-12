using SmallProject.UserService.Domain.Aggregates.Retailer;
using SmallProject.UserService.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Infrastructure.Implementations.Repositories
{
    public class RetailerRepository : IRetailerRepository
    {
        private readonly UserDbContext _context;

        public RetailerRepository(UserDbContext context)
        {
            _context = context;
        }

        public bool Add(Retailer retailer)
        {
            _context.Retailers.Add(retailer);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Retailer> GetAll(string query)
        {
            throw new NotImplementedException();
        }

        public Retailer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Retailer retailer, int id)
        {
            throw new NotImplementedException();
        }
    }
}
