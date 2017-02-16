using Customers;
using System.Collections.Generic;

namespace Interface
{
    public interface IQueryManager<TModel> where TModel : class
    {
        List<Customer> GetAll();
    }
}
