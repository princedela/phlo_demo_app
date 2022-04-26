using System;
using DemoCore.Data.Models;

namespace DemoCore.Data.DBContext
{
    public static class InitialDataGenerator
    {
   
        public static void AddProductsToCache(AppDBContext context)
        {
            context.Products.Add(new Product() { Id = 1, Name = "Book" });
            context.Products.Add(new Product() { Id = 2, Name = "Pen" });
            context.Products.Add(new Product() { Id = 3, Name = "Umbrella" });
            context.Products.Add(new Product() { Id = 4, Name = "Laptop" });
            context.Products.Add(new Product() { Id = 5, Name = "Phone" });
            context.Products.Add(new Product() { Id = 6, Name = "Keyboard" });
            context.Products.Add(new Product() { Id = 7, Name = "Paper" });
            context.SaveChanges();
        }
    }
}
