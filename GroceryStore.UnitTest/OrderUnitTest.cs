using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.DTO;
using GroceryStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GroceryStore.UnitTest
{
    public class OrderUnitTest
    {
        public OrderController controller;

        public IOrderRepository orderRepository;

        public int orderId;

        public OrderUnitTest()
        {
            controller = new OrderController(orderRepository);
        }

        [Fact]
        public void List_WhenCalled_ReturnsAllOrders()
        {
            var result = controller.List() as IEnumerable<Order>;
            var items = Assert.IsAssignableFrom<IEnumerable<Order>>(result);
            Assert.NotEmpty(items);
        }        

        [Fact]
        public void Get_WhenExistingIdPassed_ReturnsOrderDetails()
        {
            var testId = 1;
            var result = controller.Get(testId) as ActionResult<Order>;
            Assert.IsType<Order>(result.Value);
            Assert.Equal(testId, (result.Value as Order).Id);
        }

        [Fact]
        public void Get_WhenNonExistingIdPassed_ReturnsNotFound()
        {
            var testId = 1000;
            var result = controller.Get(testId) as ActionResult<Order>;
            Assert.IsType<Order>(result.Value);
            Assert.Equal(testId, (result.Value as Order).Id);
        }

        [Fact]
        public void GetByCustomer_WhenExistingCustomerIdPassed_ReturnsListOfOrdersForThatCustomer()
        {
            int customerId = 1;
            var okResult = controller.GetByCustomer(customerId);
            Assert.IsAssignableFrom<IEnumerable<Order>>(okResult);
        }

        [Fact]
        public void GetByCustomer_WhenNonExistingCustomerIdPassed_ReturnsNoContent()
        {
            int customerId = 1000;
            var okResult = controller.GetByCustomer(customerId);
            Assert.IsAssignableFrom<IEnumerable<Order>>(okResult);
        }

        [Fact]
        public void GetByDate_WhenPassedWithADate_ReturnsListOfOrdersForThatDate()
        {
            DateTime dateTime = DateTime.Now;
            var okResult = controller.GetByDate(dateTime);
            Assert.IsAssignableFrom<IEnumerable<Order>>(okResult);
        }
    }
}
