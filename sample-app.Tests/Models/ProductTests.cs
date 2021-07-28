using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace sample_app.Tests.Models
{
    public class ProductTests
    {
        // Test Case 1
        [Fact]
        public void CanChangeProductName()
        {
            // Arrange : Setting up the object required to carry testing
            var p = new Product
            {
                Name = "Product 1"
            };
            // Act :  Perform the test 
            p.Name = "Product 2";
            // Assert
            Assert.Equal("Product 2", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // Arrange
            var p = new Product
            {
                Price =10
            };
            // Act
            p.Price = 100;
            // Assert

            Assert.NotEqual(101, p.Price);
        }
    }
}
