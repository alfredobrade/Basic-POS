using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.DAL.Context;
using PointOfSale.DAL.IRepository;
using PointOfSale.Models;
using Microsoft.EntityFrameworkCore;
using PointOfSale.BL.IServices;
using System.Security.Claims;

namespace BasicPointOfSale.Controllers
{
    public class BusinessUnitController : Controller
    {
        private readonly ILogger<BusinessUnit> _logger;
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IUserService _UserService;
        private readonly ICashRegisterService _cashRegisterService;
        private readonly string _userEmail;

        public BusinessUnitController(ILogger<BusinessUnit> logger, 
            IBusinessUnitService businessUnitService,
            IUserService userService,
            ICashRegisterService cashRegisterService,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _businessUnitService = businessUnitService;
            _UserService = userService;
            _cashRegisterService = cashRegisterService;
            _userEmail = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        }

        // GET: BusinessUnitController
        public async Task<IActionResult> Index()
        {
            try
            {
                //TODO: Agregar logica de usuario logueado
                var user = await _UserService.GetByEmail(_userEmail);

                var businessList = await _businessUnitService.GetBusinessUnits(user.Id);
                return View(businessList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> SelectBusiness(int BusinessUnitId)
        {
            try
            {
                // Guardar el NegocioId en la sesión
                HttpContext.Session.SetInt32("BusinessUnitId", BusinessUnitId); //TODO: manejar aca para que no venga vacio

                // Redireccionar a la vista que desees mostrar después de seleccionar el negocio
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> CloseBusiness()
        {
            try
            {
                // Guardar el NegocioId en la sesión
                HttpContext.Session.Remove("BusinessUnitId");

                // Redireccionar a la vista que desees mostrar después de seleccionar el negocio
                return RedirectToAction("Index", "BusinessUnit");
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
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: BusinessUnitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewBusinessUnit(BusinessUnit model)
        {
            try
            {
                var user = await _UserService.GetByEmail(_userEmail);
                if (user == null) return RedirectToAction("Index", "BusinessUnit");
                await _businessUnitService.NewBusinessUnit(user.Id ,model);
                await _cashRegisterService.NewCashRegister(model.Id);
                return RedirectToAction("Index","BusinessUnit");
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessUnitController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: BusinessUnitController/Edit/5
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

        // GET: BusinessUnitController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: BusinessUnitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
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

        public async Task<ActionResult> ExitBusiness()
        {
            try
            {
                HttpContext.Session.Remove("BusinessUnitId");

                return RedirectToAction("Index", "BusinessUnit");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
