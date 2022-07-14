using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using AlbumPrinter.Model;
using AlbumPrinter.Services;
using AlbumPrinter.Controllers;

namespace Test
{
    public class OrderControllerTest
    {
        private OrderController ordercontroller;

        public OrderControllerTest()
        {
            ordercontroller = new OrderController(new OrderService());
        }

        [Fact]
        public void CreateOrderTest()
        {
            Order or = new Order(1, new List<Product>()
            {
                new Product()
                {
                    Type = ProductType.PhotoBook,
                    Quantity = 2
                },
                new Product()
                {
                    Type= ProductType.Mug,
                    Quantity =2
                }});
            var expectedSize = 132;
            ordercontroller.CreateOrder(or);

            var response = ordercontroller.GetOrder(or.OrderId);
            var result = (ActionResult<Order>)response.Result;
            Assert.NotNull(result);

            var objectResult = (OkObjectResult)result.Result;
            Assert.NotNull(objectResult);

            Assert.Equal(((Order)objectResult.Value).RequiredBinWidth, expectedSize, 2);

        }

        [Fact]
        public void InvalidOrderIdTest()
        {
            Order or = new Order(-1, new List<Product>()
            {
                new Product()
                {
                    Type = ProductType.PhotoBook,
                    Quantity = 2
                }
             });

            var response = ordercontroller.CreateOrder(or);
            var result = (BadRequestResult)response.Result;
            Assert.NotNull(result);
        }

        [Fact]
        public void InvalidQuantityTest()
        {
            Order or = new Order(1, new List<Product>()
            {
                new Product()
                {
                    Type = ProductType.PhotoBook,
                    Quantity = 0
                }
            });

            var response = ordercontroller.CreateOrder(or);
            var result = (BadRequestResult)response.Result;
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateOrder4MugTest()
        {
            Order or = new Order(1, new List<Product>()
            {
                new Product()
                {
                    Type = ProductType.PhotoBook,
                    Quantity = 2
                },
                new Product()
                {
                    Type= ProductType.Mug,
                    Quantity =4
                }});
            var expectedSize = 132;
            ordercontroller.CreateOrder(or);

            var response = ordercontroller.GetOrder(or.OrderId);
            var result = (ActionResult<Order>)response.Result;
            Assert.NotNull(result);

            var objectResult = (OkObjectResult)result.Result;
            Assert.NotNull(objectResult);

            Assert.Equal(((Order)objectResult.Value).RequiredBinWidth, expectedSize, 2);
        }

        [Fact]
        public void CreateOrder5MugTest()
        {
            Order or = new Order(1, new List<Product>()
            {
                new Product()
                {
                    Type = ProductType.PhotoBook,
                    Quantity = 2
                },
                new Product()
                {
                    Type= ProductType.Mug,
                    Quantity = 5
                }});
            var expectedSize = 226;
            ordercontroller.CreateOrder(or);

            var response = ordercontroller.GetOrder(or.OrderId);
            var result = (ActionResult<Order>)response.Result;
            Assert.NotNull(result);

            var objectResult = (OkObjectResult)result.Result;
            Assert.NotNull(objectResult);

            Assert.Equal(((Order)objectResult.Value).RequiredBinWidth, expectedSize, 2);
        }
    }
}
