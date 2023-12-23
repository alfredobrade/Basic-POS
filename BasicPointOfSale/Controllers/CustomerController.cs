using BasicPointOfSale.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PointOfSale.BL.IServices;
using PointOfSale.BL.Services;
using PointOfSale.Models;

namespace BasicPointOfSale.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: CustomerController
        public async Task<ActionResult> Index(string? name)
        {
            try
            {

                var BusinessUnitId = (int)HttpContext.Session.GetInt32("BusinessUnitId");
                if (BusinessUnitId == null) return RedirectToAction("Index", "BusinessUnit");


                var list = await _customerService.GetCustomerList(BusinessUnitId);
                if (name != null) list = list.Where(c => c.Name.ToLower().Contains(name.ToLower()));

                var model = new CustomerListVM()
                {
                    BusinessUnitId = BusinessUnitId,
                    Customers = list
                };
                

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: CustomerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public async Task<ActionResult> NewCustomer(int BusinessUnitId)
        {
            try
            {
                var customer = new Customer()
                {
                    BusinessUnitId = BusinessUnitId
                };

                return View(customer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewCustomer(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _customerService.CreateCustomer(customer); 
                }

                return RedirectToAction("Index","Customer");
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public async Task<ActionResult> Delete(int CustomerId)
        {
            try
            {
                var customer = await _customerService.GetCustomer(CustomerId);
                return View(customer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Customer customer)
        {
            try
            {

                if (customer.Id != 0) await _customerService.DeleteCustomer(customer);

                return RedirectToAction("Index", "Customer");
            }
            catch
            {
                return View(customer);

            }
        }
    }
}
