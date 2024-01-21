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
        private readonly ICashRegisterService _cashRegisterService;
        private readonly ICustomerService _customerService;

        public SaleHistoryController(ISaleService service, 
            ISaleProductService spService,
            IProductService productService,
            ICashRegisterService cashRegisterService,
            ICustomerService customerService)
        {
            _service = service;
            _spService = spService;
            _productService = productService;
            _cashRegisterService = cashRegisterService;
            _customerService = customerService;
        }

        // GET: SaleHistoryController
        public async Task<ActionResult> Index(DateTime date, string customer)
        {
            try
            {
                var businessUnitId = HttpContext.Session.GetInt32("BusinessUnitId");
                if (businessUnitId == null) return RedirectToAction("Index", "BusinessUnit");

                //if (date.Year < 2000) date = null;
                var sales = await _service.GetSaleList(businessUnitId, date, customer);

                //TODO: Falta la lista de nombres de los clientes
                //var customers = _customerService.GetCustomerList((int)businessUnitId);
                //foreach ( var item in sales)//esto ya no debería ser necesario
                //{
                //    item.Customer = await _customerService.GetCustomer((int)item.CustomerId);
                //}

                var model = new SaleListVM()
                {
                    BusinessUnitId = (int)businessUnitId,
                    Sales = sales.OrderByDescending(s => s.DateTime).ToList()
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
                var BusinessUnitId = HttpContext.Session.GetInt32("BusinessUnitId");
                if (BusinessUnitId == null) return RedirectToAction("Index", "BusinessUnit");

                var products = await _service.SaleDetail(model.Sale.Id);
                if (products != null)
                {
                    foreach (var item in products)
                    {
                        var product = await _productService.GetProduct(item.ProductId);
                        product.Stock += item.Quantity;
                        await _productService.EditProduct(product);
                    }
                }
                await _cashRegisterService.AddIncome((int)BusinessUnitId, model.Sale.Price);
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
