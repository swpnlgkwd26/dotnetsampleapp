using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public class CustomerSQLRespository : ICustomerRespository
    {
        private readonly TataPowerDataContext context;

        public CustomerSQLRespository(TataPowerDataContext context)
        {
            this.context = context;
        }
        public IEnumerable<Customer> Customers => context.Customers;

        public void AddCustomer(Customer customer)
        {
            
            context.Customers.Add(customer);
           
            context.SaveChanges();
        }

        public bool DeleteCustomer(int id)
        {
            var customer = context.Customers.Find(id);
            context.Customers.Remove(customer);
            context.SaveChanges();
            return true;
        }

        public Customer GetCustomerById(int id)
        {
            return context.Customers.Find(id);
        }

        public bool UpdateCustomer(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
            return true;
        }
    }
}
