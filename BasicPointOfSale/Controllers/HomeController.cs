using BasicPointOfSale.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSale.BL.IServices;
using PointOfSale.BL.Services;
using PointOfSale.DAL.Context;
using System.Diagnostics;

namespace BasicPointOfSale.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICashRegisterService _cashRegisterService;

        public HomeController(ILogger<HomeController> logger, ICashRegisterService cashRegisterService)
        {
            _logger = logger;
            _cashRegisterService = cashRegisterService;

        }

        public async Task<IActionResult> Index()
        {
            try
            {
                int? BusinessUnitId = HttpContext.Session.GetInt32("BusinessUnitId");
                if (BusinessUnitId == null) return RedirectToAction("Index", "BusinessUnit");

                //TODO: Dashboard 
                var cashRegister = await _cashRegisterService.ViewCashRegister((int)BusinessUnitId);
                var model = new DashBoardVM()
                {
                    BusinessUnitId = BusinessUnitId,
                    CashRegister = cashRegister
                };
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}