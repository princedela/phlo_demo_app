using System;
using DemoCore.Data.Models;

namespace DemoCore.Models
{
    public class SalesItemViewModel
    {
        public SalesItemViewModel()
        {
        }
        public SalesItemViewModel(SalesOrder order)
        {
            Id = order.Id;
            CustomerName = order.CustomerName;
            Price = order.Price;
            DateCreated = order.DateCreated;
            Product = order.Product;
        }
        
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
