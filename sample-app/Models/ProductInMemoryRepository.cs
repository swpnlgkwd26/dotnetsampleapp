using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public class ProductInMemoryRepository : IStoreRepository
    {
        // Dummy List
        static List<Product> products = new List<Product>
        {
            // C# Collection Initializer Syntax
            new Product
            {
                ProductId=1,
                Name="Chess Board",
                Price=23,
                Category="Chess",
                Description="This is Chess Board"
            },
            new Product
            {
                ProductId=11,
                Name="Chess Board Again",
                Price=23,
                Category="Chess",
                Description="This is Chess Board"
            },
            new Product
            {
                ProductId=12,
                Name="Chess PAwns",
                Price=23,
                Category="Chess",
                Description="This is Chess Board"
            },
             new Product
            {
                ProductId=2,
                Name="Bat",
                Price=23,
                Category="Cricket",
                Description="This is electronics"
            },
              new Product
            {
                ProductId=3,
                Name="Net",
                Price=23,
                Category="Soccer",
                Description="This is Soccer"
            }

        };

        // Return a Products
        public IEnumerable<Product> Products =>
            products;

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public bool DeleteProduct(int id)
        {
            // Find Product that i want to remove
            var product = products.Find(x => x.ProductId == id);
            products.Remove(product);
            return true;
        }

        public Product GetProductById(int id)
        {
            // Find Product By ID and Return it
            var product = products.Find(x => x.ProductId == id);
            return product;
        }

        public bool UpdateProduct(Product product)
        {
            // Find the Product
            var productToUpdate = products.Find(x => x.ProductId == product.ProductId);

            productToUpdate.ProductId = product.ProductId;
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Category = product.Category;
            productToUpdate.Description = product.Description;
            productToUpdate.MfgDate = product.MfgDate;

            return true;
        }
    }
}
