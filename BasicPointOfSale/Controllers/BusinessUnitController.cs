using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.DAL.IRepository;
using PointOfSale.Models;

namespace BasicPointOfSale.Controllers
{
    public class BusinessUnitController : Controller
    {
        private readonly IGenericRepository<BusinessUnit> _context;
        // GET: BusinessUnitController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BusinessUnitController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusinessUnitController/Create
        public async Task<ActionResult> NewBusinessUnit()
        {
            return View();
        }

        // POST: BusinessUnitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewBusinessUnit(BusinessUnit model)
        {
            try
            {
                await _context.Create(model);
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessUnitController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BusinessUnitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: BusinessUnitController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusinessUnitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
