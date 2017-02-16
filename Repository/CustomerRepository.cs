using Models;
using Interface;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public Customer Insert(Customer entity)
        {
            throw new NotImplementedException();
        }
        public int Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public object Update(object id, Customer entity)
        {
            throw new NotImplementedException();
        }
        public List<Customer> GetSomeCustomers(int startIndex, int limit)
        {
            return GetAll().OrderBy(x => x.Id).Skip(startIndex).Take(limit).ToList();
        }
    }
}
