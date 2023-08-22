using BasicPointOfSale.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.BL.IServices;
using PointOfSale.Models;
using System.ComponentModel;

namespace BasicPointOfSale.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public async Task<ActionResult> Index(string? code, string? description)
        {
            try
            {

                var BusinessUnitId = HttpContext.Session.GetInt32("BusinessUnitId");
                if(BusinessUnitId == null) return RedirectToAction("Index", "BusinessUnit");


                var list = await _productService.FilterList(BusinessUnitId, code, description);


                var model = new ProductListVM()
                {
                    BusinessUnitId = (int)BusinessUnitId,
<<<<<<< HEAD
                    Products = list.OrderBy(p => p.Description).ToList()
=======
                    Products = list.OrderBy(p => p.Description).ToList(),
>>>>>>> 62f6f18389e4d9d5dbcff5afb9241daaec0e259f
                };

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> SearchProduct(long SaleId, string? code, string? description)
        {
            try
            {
                var BusinessUnitId = HttpContext.Session.GetInt32("BusinessUnitId");
                if (BusinessUnitId == null) return RedirectToAction("Index", "BusinessUnit");

                var list = await _productService.FilterList(BusinessUnitId, code, description);


                var model = new ProductListVM()
                {
                    BusinessUnitId = (int)BusinessUnitId,
                    SaleId = SaleId,
<<<<<<< HEAD
                    Products = list.OrderBy(p => p.Description).ToList()
=======
                    Products = list.OrderBy(p => p.Description)
>>>>>>> 62f6f18389e4d9d5dbcff5afb9241daaec0e259f
                };

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public async Task<ActionResult> NewProduct(int BusinessUnitId)
        {
            var product = new Product()
            {
                BusinessUnitId = BusinessUnitId
            };
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewProduct(Product product)
        {
            try
            {
                var result = await _productService.CreateProduct(product);
                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(long ProductId)
        {
            try
            {
                var product = await _productService.GetProduct(ProductId);
                return View(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            try
            {
                if (product != null) await _productService.EditProduct(product);

                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return View(product);
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(long ProductId)
        {
            try
            {
                var product = await _productService.GetProduct(ProductId);
                return View(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Product product)
        {
            try
            {

                if (product.Id != 0) await _productService.DeleteProduct(product);

                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return View(product);

            }
        }
    }
}
