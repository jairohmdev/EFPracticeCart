﻿using Interface;
using System.Collections.Generic;
using System.Linq;
using System;
using Models;

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

        public bool Insert(Customer entity)
        {
            try
            {
                _dbContext.Customers.Add(entity);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
                _dbContext.Customers.Remove(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return (_dbContext.SaveChanges() == 1) ? true : false;
        }

        public bool Update(Customer entity)
        {
            try
            {
                Customer customer = GetAll().Where(c => c.Id == entity.Id).First();
                customer.Name = entity.Name;
                customer.Address = entity.Address;
                customer.City = entity.City;
                customer.Zip = entity.Zip;
                customer.State = entity.State;

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public List<Customer> GetSomeCustomers(int startIndex, int limit)
        {
            return GetAll().OrderBy(x => x.Id).Skip(startIndex).Take(limit).ToList();
        }
    }
}
