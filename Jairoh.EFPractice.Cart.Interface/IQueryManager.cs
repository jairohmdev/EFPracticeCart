using Models;
using System.Collections.Generic;

namespace Interface
{
    public interface IQueryManager<TModel> where TModel : class
    {
        List<Customer> GetAll();
        TModel Insert(TModel entity);
        int Delete(TModel entity);
        object Update(object id, TModel entity);
    }
}
