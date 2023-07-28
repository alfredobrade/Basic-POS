using BasicPointOfSale.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.BL.IServices;
using PointOfSale.Models;

namespace BasicPointOfSale.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index(UserVM userVM)
        {

            var Id = userVM.Id;

            return View(userVM);
        }

        // GET: VehicleController/Create
        public async Task<ActionResult> NewUser()
        {

            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewUser(UserVM userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User()
                    {
                        Email = userVM.Email,
                        Name = userVM.Name,
                        Password = userVM.Password
                    };



                    user = await _service.Create(user);
                    userVM.Id = user.Id;
                    return RedirectToAction("Index", "User", userVM);
                }
                else
                {
                    return View(userVM);
                }
            }
            catch
            {
                return View(userVM);
            }
        }


        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
