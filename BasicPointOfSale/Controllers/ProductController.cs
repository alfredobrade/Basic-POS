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
        public async Task<ActionResult> Index()
        {
            try
            {
                var BusinessUnitId = HttpContext.Session.GetInt32("BusinessUnitId");

                var list = await _productService.GetList(BusinessUnitId);
                var model = new ProductListVM()
                {
                    BusinessUnitId = (int)BusinessUnitId,
                    Products = list
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
                BusinessId = BusinessUnitId
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
                var result = await _productService.Create(product);
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
                if (product != null) await _productService.Edit(product);

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

                if (product.Id != 0) await _productService.Delete(product);

                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return View(product);

            }
        }
    }
}
