using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public interface ICustomerRespository
    {
        IEnumerable<Customer> Customers { get; }
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        bool DeleteCustomer(int id);

        bool UpdateCustomer(Customer customer);
    }
}
