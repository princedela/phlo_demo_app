using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoCore.Models;
using DemoCore.Data.DBContext;
using DemoCore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCore.Controllers
{
    public class ProductController : Controller
    {
        private ILogger<ProductController> _logger;
        private AppDBContext _context;

        public ProductController(ILogger<ProductController> logger,AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Welcome()
        {
            return View();
        }

         public IActionResult Index()
        {
            var model = new OrderViewModel();
            try
            {
                ViewBag.Products =  _context.Products.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return View(model);
        }

        [HttpPost]
        public  IActionResult Index(OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var order = new SalesOrder()
                    {
                        CustomerName = model.Customer,
                        ProductId = model.ProductId,
                        Price = model.Price,
                        DateCreated = DateTime.Now
                    };
                    _context.SalesOrders.Add(order);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(List),new { message = "Order added successfully" });
                }
                ViewBag.Products = _context.Products.ToList();
                return View(model);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult List(string message = "")
        {
            ViewBag.Message = message;
            var model = new ListViewModel
            {
                Orders = _context.SalesOrders.Include(s => s.Product).AsEnumerable()
                    .GroupBy(s => s.ProductId)
                    .Select(group => new SalesOrderViewModel
                    {
                        ProductId = group.Key,
                        HighestPrice = group.Max(g => g.Price),
                        LowestPrice = group.Min(g => g.Price),
                        SalesRecords = group.ToList()
                    }).ToList()
            };
            return View(model);
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
