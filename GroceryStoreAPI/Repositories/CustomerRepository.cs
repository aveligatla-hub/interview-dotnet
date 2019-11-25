using GroceryStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ICosmosDataBase cosmosDb;

        public CustomerRepository(ICosmosDataBase jsonDatabase)
        {
            cosmosDb = jsonDatabase;
        }

        public IEnumerable<Customer> List()
        {
            return cosmosDb.GetData().Customers;
        }

        public Customer Get(int id)
        {
            return cosmosDb
                .GetData()
                .Customers
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public Customer Create(Customer customer)
        {
            CosmosData data = cosmosDb.GetData();
            List<Customer> customers = data.Customers.Where(c => c.Id != customer.Id).ToList();
            customers.Add(customer);

            data.Customers = customers;

            cosmosDb.SaveData(data);

            return customer;
        }
    }
}
