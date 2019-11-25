using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.DTO;
using GroceryStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{   
    [Route("api/order")]
    [ApiController]
    public class OrderController : Controller
    {
        IOrderRepository orderRepository;

        /// <summary>
        /// Order Repository Constructor
        /// </summary>
        /// <param name="orderRepository"></param>
        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        /// <summary>
        /// API listing all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Order> List()
        {
            return orderRepository.List();
        }

        /// <summary>
        /// API retrieving an order using Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            Order order = orderRepository.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        /// <summary>
        /// API list a customer's orders
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("customer/{customerId}")]
        public IEnumerable<Order> GetByCustomer(int customerId)
        {
            IEnumerable<Order> orders = orderRepository.GetByCustomer(customerId);

            return orders;
        }

        /// <summary>
        /// API listing all orders for a given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("date/{date}")]
        public IEnumerable<Order> GetByDate(DateTime date)
        {
            IEnumerable<Order> orders = orderRepository.GetByDate(date);

            return orders;
        }
    }
}