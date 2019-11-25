using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.DTO;
using GroceryStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{    
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        /// <summary>
        /// API listing products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Product> List()
        {
            return productRepository.List();
        }

        /// <summary>
        /// API retrieving a product using Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product = productRepository.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// API saving a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product product)
        {
            Product savedProduct = productRepository.Create(product);

            return savedProduct;
        }
    }
}