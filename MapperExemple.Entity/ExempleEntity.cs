﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperExemple.Entity
{
    public class ExempleEntity
    {
        public Customer GetFirstCustomer()
        {
            using (MyDbContext context = new MyDbContext())
            {
                context.Database.Log = x => Debug.WriteLine(x);
                var result = from c in context.Customers
                             select c;
                return result.FirstOrDefault();
            }
        }

        public IQueryable<Customer> GetCustomers()
        {
            MyDbContext context = new MyDbContext();
            context.Database.Log = x => Debug.WriteLine(x);
            var result = from c in context.Customers
                         select c;
            return result;

        }

        public List<Customer> GetCustomersList()
        {
            using (MyDbContext context = new MyDbContext())
            {
                context.Database.Log = x => Debug.WriteLine(x);
                var result = from c in context.Customers
                             select c;
                return result.ToList();
            }
        }
    }
}
