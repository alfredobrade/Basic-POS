using Microsoft.AspNetCore.Mvc;

namespace BasicPointOfSale.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
