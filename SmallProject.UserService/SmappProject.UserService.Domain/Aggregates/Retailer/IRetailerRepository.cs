﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Domain.Aggregates.Retailer
{
    public interface IRetailerRepository
    {
        IEnumerable<Retailer> GetAll(string query);
        Retailer GetById(int id);
        bool Add(Retailer retailer);
        bool Update(Retailer retailer, int id);
        bool Delete(int id);
    }
}