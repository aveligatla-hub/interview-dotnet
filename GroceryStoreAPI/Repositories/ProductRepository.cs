using GroceryStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ICosmosDataBase cosmosDb;

        public ProductRepository(ICosmosDataBase cosmosDatabase)
        {
            cosmosDb = cosmosDatabase;
        }

        public IEnumerable<Product> List()
        {
            return cosmosDb.GetData().Products;
        }

        public Product Get(int id)
        {
            return cosmosDb
                .GetData()
                .Products
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public Product Create(Product product)
        {
            CosmosData data = cosmosDb.GetData();
            List<Product> products = data.Products.Where(p => p.Id != product.Id).ToList();
            products.Add(product);

            data.Products = products;

            cosmosDb.SaveData(data);

            return product;
        }
    }
}
