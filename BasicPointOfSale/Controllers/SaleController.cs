using BasicPointOfSale.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.BL.IServices;
using PointOfSale.BL.Services;
using PointOfSale.Models;

namespace BasicPointOfSale.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _service;
        private readonly IProductService _productService;
        private readonly ISaleProductService _spService;
        private readonly ICashRegisterService _cashRegisterService;

        public SaleController(ISaleService service, IProductService productService, ISaleProductService spService, ICashRegisterService cashRegisterService)
        {
            _service = service;
            _spService = spService;
            _cashRegisterService = cashRegisterService;
            _productService = productService;
        }
        // GET: SaleController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public async Task<ActionResult> NewSale()
        {
            try
            {
                var BusinessUnitId = (int)HttpContext.Session.GetInt32("BusinessUnitId"); //TODO: manejar el nullable
                if (BusinessUnitId == null) return RedirectToAction("Index", "BusinessUnit");

                var model = new SaleVM()
                {
                    BusinessUnitId = BusinessUnitId,
                };

                var openSale = await _service.GetOpenSale(BusinessUnitId);
                if (openSale != null)
                {
                    model.Sale = openSale;
                    model.Products = await _service.SaleDetail(openSale.Id);

                    foreach (var item in model.Products)
                    {
                        //TODO: logica para avisar que la cantidad deja debajo de stock minimo

                    }
                    return View(model);
                }

                var newSale = await _service.NewSale(BusinessUnitId);
                model.Sale = newSale;
                model.Products = new List<SaleProduct>();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewSale(SaleVM saleVM)  //este activa solo en el submit
        {
            try
            {
                if (saleVM.Sale.CustomerName == null) saleVM.Sale.CustomerName = "Consumidor final";
                var sale = await _service.CloseSale(saleVM.Sale.Id, saleVM.Sale.CustomerName);

                var cashRegister = await _cashRegisterService.AddIncome(saleVM.BusinessUnitId, sale.Price);
                
                    var saleDetail = await _service.SaleDetail(sale.Id);
                if (saleDetail != null)
                { 
                    foreach (var item in saleDetail)
                    {
                        var product = await _productService.GetProduct(item.ProductId);
                        //modifico el stock
                        product.Stock = item.Product.Stock - item.Quantity;
                        await _productService.EditProduct(product);
                    }
                    return RedirectToAction("Index", "SaleHistory");
                }
                else
                {
                    return View(saleVM);
                }
                //close sale
                //update CashRegister
                //saledetail - saleId
                //foreach
                //GetProduct - product.Id
                //EditProduct stock - product.Id


            }
            catch
            {
                return View(saleVM);
            }
        }

        // GET: SaleController/Delete/5
        public async Task<ActionResult> Cancel(long saleId)
        {
            try
            {
                var sale = await _service.GetSaleById(saleId);
                return View(sale);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cancel(Sale sale)
        {
            try
            {
                var result = await _service.CancelSale(sale.Id);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(sale);
            }
        }

        public async Task<ActionResult> AddItem(long SaleId, long ProductId)
        {
            try
            {
                var model = new SaleProductVM()
                {
                    SaleId = SaleId,
                    Product = await _productService.GetProduct(ProductId),
                    Quantity = 1
                };
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddItem(SaleProductVM model)
        {
            try
            {
                if (model.Product.Stock < model.Quantity) return RedirectToAction("QuantityOverStock", "Sale", model);

                var result = await _service.AddProduct(model.SaleId, model.Product.Id, (int)model.Quantity);

                //TODO: agregar metodo para pasarle el precio
                

                return RedirectToAction("NewSale", "Sale");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: SaleController/Edit/5
        public async Task<ActionResult> EditItem(long SaleId, long ProductId)
        {
            try
            {
                var saleProduct = await _spService.GetSaleProduct(SaleId, ProductId);
                var model = new SaleProductVM()
                {
                    SaleId = SaleId,
                    Product = await _productService.GetProduct(ProductId),
                    Quantity = saleProduct.Quantity
                };

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditItem(SaleProductVM model)
        {
            try
            {
                var saleProduct = new SaleProduct()
                {
                    SaleId = model.SaleId,
                    ProductId = model.Product.Id,
                    Quantity = model.Quantity,
                    Cost = model.Product.Cost,
                    Price = model.Product.Price
                };
                await _spService.UpdateSaleProduct(saleProduct);
                return RedirectToAction("NewSale", "Sale"); 
            }
            catch
            {
                return View(model);
            }
        }

        // GET: SaleController/Delete/5
        public async Task<ActionResult> DeleteItem(long SaleId, long ProductId)
        {
            try
            {
                var saleProduct = await _spService.GetSaleProduct(SaleId, ProductId);
                var model = new SaleProductVM()
                {
                    SaleId = SaleId,
                    Product = await _productService.GetProduct(ProductId),
                    Quantity = saleProduct.Quantity
                };

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteItem(SaleProductVM model)
        {
            try
            {
                
                await _spService.DeleteSaleProduct(model.SaleId, model.Product.Id);
                return RedirectToAction("NewSale", "Sale");
            }
            catch
            {
                return View(model);
            }
        }

        public async Task<ActionResult> QuantityOverStock(SaleProductVM model)
        {
            try
            {
                

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
