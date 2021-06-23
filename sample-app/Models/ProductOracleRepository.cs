using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public class ProductIOracleepository : IStoreRepository
    {
        // Dummy List
        static List<Product> products = new List<Product>
        {
            // C# Collection Initializer Syntax
            new Product
            {
                ProductId=1,
                Name="OracleChess Board",
                Price=23,
                Category="Chess",
                Description="This is Chess Board"
            },
             new Product
            {
                ProductId=2,
                Name="OracleBat",
                Price=23,
                Category="Cricket",
                Description="This is electronics"
            },
              new Product
            {
                ProductId=3,
                Name="OracleNet",
                Price=23,
                Category="Soccer",
                Description="This is Soccer"
            }

        };

        // Return a Products
        public IEnumerable<Product> Products =>
            products;
    }
}
