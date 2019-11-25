using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.DTO;
using GroceryStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        /// <summary>
        /// API listing all customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Customer> List()
        {
            return customerRepository.List();
        }

        /// <summary>
        /// API retrieving a customer using Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer customer = customerRepository.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        /// <summary>
        /// API saving a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Customer> Create([FromBody] Customer customer)
        {
            Customer savedCustomer = customerRepository.Create(customer);

            return savedCustomer;
        }
    }
}