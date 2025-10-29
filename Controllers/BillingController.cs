using Microsoft.AspNetCore.Mvc;
using System.Web;
using RestaurantBillingApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantBillingApp.Controllers
{
     public class BillingController : Controller
     {
        private static List<MenuItem> Menu = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Pizza", Price = 150},
                new MenuItem { Id = 2, Name = "Burger", Price = 80 },

                new MenuItem { Id = 3, Name = "Veg-Paneer", Price = 100 },
                new MenuItem { Id = 4, Name = "Panner Butter Masala", Price = 120 },

                new MenuItem { Id = 5, Name = "Mutton Curry", Price = 150},
                new MenuItem { Id = 6, Name = "Mutton Biriyani", Price = 180 }, 
                
                new MenuItem { Id = 7, Name = "Grill Chicken", Price = 140 },
                new MenuItem { Id = 8, Name = "Chicken 65", Price = 65},
                new MenuItem { Id = 9, Name = "Chicken Burger", Price = 140 },
               
                new MenuItem { Id = 10, Name = "Vennila Icecream", Price = 60 },
                new MenuItem { Id = 11, Name = "Stawberry Icecream", Price = 70},
                new MenuItem { Id = 12, Name = "Chocalate Icecream", Price = 65},
               
                new MenuItem { Id = 13, Name = "Lemon Juice", Price = 30},
                new MenuItem { Id = 14, Name = "Mango Juice", Price = 35},
                new MenuItem { Id = 15, Name = "Watermelon Juice", Price = 35},
              
                new MenuItem { Id = 16, Name = "Boost Mixer", Price = 15},
                new MenuItem { Id = 17, Name = "Tea", Price = 20 },
                
            };
            public IActionResult Index()
            {
                return View(Menu);
            }
            [HttpPost]
            public IActionResult 
                GenerateBill(List<MenuItem> selectedItems)
            {
                var cart = selectedItems.Where(x => x.Quantity > 0).ToList();
                decimal subtotal = cart.Sum(x => x.Price * x.Quantity);
                decimal tax = subtotal * 0.05m;
                decimal total = subtotal + tax;
                ViewBag.Subtotal = subtotal;
                ViewBag.Tax = tax;
                ViewBag.Total = total;

                return View("Bill", cart);
            }
     }
}
