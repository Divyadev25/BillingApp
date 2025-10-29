using Microsoft.AspNetCore.Mvc;

namespace RestaurantBillingApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
