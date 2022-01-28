using System;
using Xunit;
using AutomotiveStore;
using AutomotiveStore.Controllers;
using System.Collections.Generic;
using AutomotiveStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Moq;

namespace AutomotiveStoreTest
{
    public class StoreProductControllerTests
    {
        [Fact]
        public void UseRepositoryInStoreTest()
        {
            
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "test"},
                new Product {ProductID = 2, Name = "test2"}
            }).AsQueryable<Product>());

            HomeController controller = new HomeController(mock.Object);

            ProductListView result =
                controller.Index().ViewData.Model as ProductListView;

            Product[] testArray = result.Products.ToArray();
            Assert.True(testArray.Length == 2);
            Assert.Equal("test", testArray[0].Name);
            Assert.Equal("test2", testArray[1].Name);
        }

        [Fact]
        public void PagingTest()
        {
            
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "ProductTest1"},
                new Product {ProductID = 2, Name = "ProductTest2"},
                new Product {ProductID = 3, Name = "ProductTest3"},
                new Product {ProductID = 4, Name = "ProductTest4"},
                new Product {ProductID = 5, Name = "ProductTest5"},
                new Product {ProductID = 6, Name = "ProductTest6"}
            }).AsQueryable<Product>());

            HomeController controller = new HomeController(mock.Object);
            controller.AmountOfPageElement = 4;
            
            ProductListView result =
                controller.Index(2).ViewData.Model as ProductListView;

            Product[] ProductArray = result.Products.ToArray();
            Assert.True(ProductArray.Length == 2);
            Assert.Equal("ProductTest5", ProductArray[0].Name);
            Assert.Equal("ProductTest6", ProductArray[1].Name);
        }
    }
}
