using System;
using System.Collections.Generic;
using DemoCore.Data.Models;

namespace DemoCore.Models
{
    public class ListViewModel
    {
        public List<SalesOrderViewModel> Orders {get;set;}
    }

    public class SalesOrderViewModel
    {
        public SalesOrderViewModel()
        {
        }
        public int ProductId { get; set; }
        public decimal HighestPrice { get; set; }
        public decimal LowestPrice { get; set; }
        public IEnumerable<SalesOrder> SalesRecords { get; set; }
    }

}
