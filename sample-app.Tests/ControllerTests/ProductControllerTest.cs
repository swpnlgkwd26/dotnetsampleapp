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
        [Fact]
        public void CanUseRepository()
        {
            // Arrange:  Objects
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products)
                .Returns(new Product[]
                {
                    new Product{ ProductId = 1, Name= "Product 1"},
                    new Product{ ProductId = 2, Name= "Product 2"}
                });
            ProductController controller = new ProductController(mock.Object);

            // Act : Call Index Action

            IEnumerable<Product> result = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Product>;

            // Assert
            Product[] prodArray = result.ToArray();
            Assert.Equal("Product 2", prodArray[0].Name);
        }
    }
}
