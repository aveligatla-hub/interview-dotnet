using AutoFixture;
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
    public class ProductUnitTest
    {
        public ProductController controller;

        public IProductRepository obj;

        public int productId;

        public ProductUnitTest()
        {
            controller = new ProductController(obj);
        }

        [Fact]
        public void List_WhenCalled_ReturnsAllProducts()
        {
            var result = controller.List() as IEnumerable<Product>;
            var items = Assert.IsType<List<Product>>(result);
            Assert.NotEmpty(items);
        }        

        [Fact]
        public void Get_WhenExistingIdPassed_ReturnsProductDetails()
        {
            int testId = 1;
            var result = controller.Get(testId);
            Assert.IsType<ActionResult<Product>>(result.Result);
        }

        [Fact]
        public void Get_WhenNonExistingIdPassed_ReturnsNotFound()
        {
            int testId = 1;
            var result = controller.Get(testId);
            Assert.IsType<ActionResult<Product>>(result.Result);
        }

        [Fact]
        public void Create_WhenValidObjectIsPassed_ReturnsCreatedProductDetails()
        {
            var fixture = new Fixture();
            Product product = fixture.Create<Product>();
            var createdResponse = controller.Create(product);
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
    }
}
