using Customers;
using Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CustomerRepository : IQueryManager<Customer>
    {
        private readonly PracticeDBEntities _dbContext;

        public CustomerRepository()
        {
            _dbContext = new PracticeDBEntities();
        }

        public List<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public List<Customer> GetSomeCustomers( int startIndex, int limit )
        {
            return GetAll().OrderBy(x => x.Id).Skip(startIndex).Take(limit).ToList();
        }


    }
}
