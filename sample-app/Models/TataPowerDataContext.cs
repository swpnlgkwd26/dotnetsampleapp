using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public class TataPowerDataContext :DbContext
    {
        //Passing ConnectionString to the base class ctro
        public TataPowerDataContext(DbContextOptions<TataPowerDataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
