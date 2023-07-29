using BasicPointOfSale.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.BL.IServices;
using PointOfSale.Models;

namespace BasicPointOfSale.Controllers
{
    public class SaleHistoryController : Controller
    {
        private readonly ISaleService _service;
        //private readonly IProductService _productService;
        private readonly ISaleProductService _spService;
        public SaleHistoryController(ISaleService service, ISaleProductService spService)
        {
            _service = service;
            _spService = spService;
            //_productService = productService;
        }
        // GET: SaleHistoryController
        public async Task<ActionResult> Index( DateTime date, string customer)
        {
            try
            {
                var BusinessUnitId = HttpContext.Session.GetInt32("BusinessUnitId");
                if (BusinessUnitId == null) return RedirectToAction("Index", "BusinessUnit");

                //if (date.Year < 2000) date = null;
                var list = await _service.GetSaleList(BusinessUnitId, date, customer);


                var model = new SaleListVM()
                {
                    BusinessUnitId = (int)BusinessUnitId,
                    Sales = list.OrderByDescending(s => s.DateTime).ToList()
                };

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: SaleHistoryController/Details/5
        public async Task<ActionResult> SaleDetails(long SaleId)
        {
            return View();
        }

        // GET: SaleHistoryController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: SaleHistoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleHistoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: SaleHistoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleHistoryController/Delete/5
        public async Task<ActionResult> DeleteSale(long SaleId)
        {
            return View();
        }

        // POST: SaleHistoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteSale(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
