using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.DTO
{
    public class CosmosData
    {
        public CosmosData()
        {
            Customers = new List<Customer>();
            Orders = new List<Order>();
            Products = new List<Product>();
        }

        /// <summary>
        /// List of Customers
        /// </summary>
        public IEnumerable<Customer> Customers { get; set; }

        /// <summary>
        /// List of Orders
        /// </summary>
        public IEnumerable<Order> Orders { get; set; }

        /// <summary>
        /// List of Orders
        /// </summary>
        public IEnumerable<Product> Products { get; set; }
    }
}
