using Microsoft.AspNetCore.Mvc;
using Moq;
using sample_app.Controllers;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace sample_app.Tests.ControllerTests
{
    public class ProductControllerTest
    {
        // Repository : Working or not
        // Test Case
        [Fact]
        public void CanUseRepository()
        {
            // Arrange :  Creation of necessary infra. Objects
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products)
                .Returns(new Product[]
                {
                    new Product{ProductId =1, Name ="Product1"},
                    new Product{ProductId =2, Name ="Product2"}
                });
            ProductController controller = new ProductController(mock.Object);

            // Act :   Perform Test

            IEnumerable<Product> result = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Product>;

            // Assert :  Verify it : Assert is a Static Class
            Product[] Products = result.ToArray();
            Assert.Equal("Product1", Products[0].Name);
        }

        [Fact]
        public void CanPaginate()
        {
            // AAA

            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products)
                .Returns(new Product[] {
                    new Product {  ProductId = 1 , Name = "P1"},
                    new Product {  ProductId = 2 , Name = "P2"},
                    new Product {  ProductId = 3 , Name = "P3"},
                    new Product {  ProductId = 4 , Name = "P4"},
                    new Product {  ProductId = 5 , Name = "P5"},
                    new Product {  ProductId = 6 , Name = "P6"}
                });
            ProductController controller = new ProductController(mock.Object);

            // Act : Perform the test
            IEnumerable<Product> result = (controller.IndexWithPagination(3) 
                as ViewResult).ViewData.Model as IEnumerable<Product>;

            // Assert : Verification
            Product[] products = result.ToArray();
            Assert.Equal("P5", products[0].Name);
            Assert.Equal("P6", products[1].Name);
        }

    }
}
