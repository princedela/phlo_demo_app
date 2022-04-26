using System;
using DemoCore.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace DemoCore.Data.DBContext
{

        public class AppDBContext : DbContext
        {
            public AppDBContext(DbContextOptions<AppDBContext> options)
                : base(options)
            {
            }

        public DbSet<Product> Products { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }
    }
}
