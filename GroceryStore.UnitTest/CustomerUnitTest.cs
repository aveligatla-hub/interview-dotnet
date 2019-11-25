using AutoFixture;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.DTO;
using GroceryStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace GroceryStore.UnitTest
{
    public class CustomerUnitTest
    {
        public CustomerController controller;

        public ICustomerRepository obj;

        public int customerId;

        public CustomerUnitTest()
        {
            controller = new CustomerController(obj);
        }
        
        [Fact]
        public void List_WhenCalled_ReturnsAllCustomers()
        {
            var result = controller.List() as IEnumerable<Customer>;
            var items = Assert.IsType<List<Customer>>(result);
            Assert.NotEmpty(items);
        }

        [Fact]
        public void Get_WhenExistingIdPassed_ReturnsCustomerDetails()
        {
            int testId = 1;
            var result = controller.Get(testId);
            Assert.IsType<ActionResult<Customer>>(result.Result);
        }

        [Fact]
        public void Get_WhenNonExistingIdPassed_ReturnsNotFound()
        {
            int testId = 1;
            var result = controller.Get(testId);
            Assert.IsType<ActionResult<Customer>>(result.Result);
        }

        [Fact]
        public void Create_WhenValidObjectIsPassed_ReturnsCreatedCustomerDetails()
        {
            var fixture = new Fixture();
            Customer customer = fixture.Create<Customer>();
            var createdResponse = controller.Create(customer);
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
    }
}
