﻿using Models;
using System.Collections.Generic;

namespace Interface
{
    public interface IQueryManager<TModel> where TModel : class
    {
        List<Customer> GetAll();
        bool Insert(TModel entity);
        bool Delete(int id);
        bool Update(TModel entity);
    }
}
