using GroceryStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPI.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> List();

        Order Get(int id);

        IEnumerable<Order> GetByCustomer(int customerId);

        IEnumerable<Order> GetByDate(DateTime date);
    }   
}
