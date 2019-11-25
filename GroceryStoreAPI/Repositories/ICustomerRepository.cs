using GroceryStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> List();

        Customer Get(int id);

        Customer Create(Customer customer);
    }
}
