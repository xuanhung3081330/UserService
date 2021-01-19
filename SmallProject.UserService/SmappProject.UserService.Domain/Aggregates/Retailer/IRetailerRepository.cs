using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmallProject.UserService.Domain.Aggregates.Retailer
{
    public interface IRetailerRepository
    {
        IEnumerable<Retailer> GetAll();
        Retailer GetById(int id);
        bool Add(Retailer retailer);
        bool Update(Retailer retailer, int id);
        bool Delete(int id);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
