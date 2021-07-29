using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using sample_app.Components;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace sample_app.Tests.ComponentTests
{
    public class NavigationMenuTest
    {
      //  [Fact]
        public void CheckCategory()
        {
            // Category
            string categoryToSelect = "Cricket";
            // Arrange :  Infra
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
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            // Set the Category in RouteData
            target.ViewComponentContext = new Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
            {
                ViewContext = new Microsoft.AspNetCore.Mvc.Rendering.ViewContext
                {
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData()
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;

            // Act :  Perform
            string result =(string) (target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];

            // Assert : Verify
            Assert.Equal("Soccer", result);

        }

        [Fact]
        public void CheckUniqueCategories()
        {
            string categoryToSelect = "Cricket";
            // Arrange :  Infra
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products)
                .Returns(new Product[] {
                    new Product {  ProductId = 1 , Name = "P1",Category ="Cricket"},
                    new Product {  ProductId = 2 , Name = "P2",Category ="Cricket"},
                    new Product {  ProductId = 3 , Name = "P3",Category ="Cricket"},
                    new Product {  ProductId = 4 , Name = "P4",Category ="Cricket"},
                    new Product {  ProductId = 5 , Name = "P5",Category ="Soccer"},
                    new Product {  ProductId = 6 , Name = "P6",Category ="Soccer"}
                });

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            // Set the Category in RouteData
            target.ViewComponentContext = new Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
            {
                ViewContext = new Microsoft.AspNetCore.Mvc.Rendering.ViewContext
                {
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData()
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;


            // Act :  Perform
            // string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];
            IEnumerable<string> result = (target.Invoke() as ViewViewComponentResult).ViewData.Model as IEnumerable<string>;

            // Assert : Verify
            string[] categories = result.ToArray();
                         
            Assert.Equal(2, categories.Count());
            Assert.Equal("Soccer", categories[1]);
            Assert.Equal("Cricket", categories[0]);
            Assert.NotNull(categories);
        }
    }
}
