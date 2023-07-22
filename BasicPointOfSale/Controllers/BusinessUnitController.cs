using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.DAL.Context;
using PointOfSale.DAL.IRepository;
using PointOfSale.Models;
using Microsoft.EntityFrameworkCore;


namespace BasicPointOfSale.Controllers
{
    public class BusinessUnitController : Controller
    {
        private readonly IGenericRepository<BusinessUnit> _repository;
        private readonly ILogger<BusinessUnit> _logger;
        private readonly POSContext _context;
        public BusinessUnitController(ILogger<BusinessUnit> logger, IGenericRepository<BusinessUnit> repository,  POSContext context)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
        }
        // GET: BusinessUnitController
        public async Task<IActionResult> Index()
        {
            try
            {

                var business = await _context.BusinessUnits.ToListAsync();
                return View(business);
            }
            catch (Exception)
            {

                throw;
            }
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
                await _repository.Create(model);
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
