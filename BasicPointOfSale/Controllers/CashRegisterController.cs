using Microsoft.AspNetCore.Mvc;

namespace BasicPointOfSale.Controllers
{
    public class CashRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
