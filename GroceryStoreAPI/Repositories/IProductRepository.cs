using GroceryStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> List();

        Product Get(int id);

        Product Create(Product product);
    }
}
