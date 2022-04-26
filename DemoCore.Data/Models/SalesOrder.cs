using System;
namespace DemoCore.Data.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public int  ProductId{ get; set; }
        public Product Product { get; set; }
        public string CustomerName { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
