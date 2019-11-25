using GroceryStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ICosmosDataBase cosmosDb;

        public OrderRepository(ICosmosDataBase jsonDatabase)
        {
            cosmosDb = jsonDatabase;
        }

        public IEnumerable<Order> List()
        {
            return cosmosDb.GetData().Orders;
        }

        public Order Get(int id)
        {
            return cosmosDb
                .GetData()
                .Orders
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Order> GetByCustomer(int customerId)
        {
            return cosmosDb
                .GetData()
                .Orders
                .Where(x => x.CustomerId == customerId);
        }

        public IEnumerable<Order> GetByDate(DateTime date)
        {
            return cosmosDb
                .GetData()
                .Orders
                .Where(x => x.Date == date)
                .OrderByDescending(x => x.Date);
        }
    }
}
