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
        private readonly IProductService _productService;
        private readonly ISaleProductService _spService;

        public SaleHistoryController(ISaleService service, ISaleProductService spService, IProductService productService)
        {
            _service = service;
            _spService = spService;
            _productService = productService;
        }

        // GET: SaleHistoryController
        public async Task<ActionResult> Index(DateTime date, string customer)
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
            try
            {
                var sale = await _service.GetSaleById(SaleId);
                var saleDetail = await _service.SaleDetail(SaleId);
                var model = new SaleVM()
                {
                    Sale = sale,
                    Products = saleDetail
                };
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                var sale = await _service.GetSaleById(SaleId);
                var saleDetail = await _service.SaleDetail(SaleId);
                var model = new SaleVM()
                {
                    Sale = sale,
                    Products = saleDetail
                };
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: SaleHistoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteSale(SaleVM model)
        {
            try
            {
                var products = await _service.SaleDetail(model.Sale.Id);
                if (products != null)
                {
                    foreach (var item in products)
                    {
                        var product = await _productService.GetProduct(item.ProductId);
                        item.Product.Stock += item.Quantity;
                        await _productService.EditProduct(item.Product);
                    }
                }
                var result = await _service.CancelSale(model.Sale.Id);


                return RedirectToAction("Index", "SaleHistory");
            }
            catch
            {
                return View();
            }
        }
    }
}
