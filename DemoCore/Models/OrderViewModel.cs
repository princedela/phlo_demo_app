using System;
using System.ComponentModel.DataAnnotations;

namespace DemoCore.Models
{
    public class OrderViewModel
    {

        [Required]
        public string Customer { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
