using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Models;
using System.Security.Claims;
using PointOfSale.BL.IServices;
using BasicPointOfSale.Models;
using Microsoft.AspNetCore.Identity;

namespace BasicPointOfSale.Controllers
{
    public class AccessController : Controller
    {
        private readonly IUserService _service;
        public AccessController(IUserService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var userVM = new UserVM();
            userVM.UsersQtity = await _service.UsersQtity();
            return View(userVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserVM userVM)
        {
            try
            {
                //var dbUser = await _service.GetByEmail(user.Email);
                var _user = await _service.ValidateUser(userVM.Email, userVM.Password);

                if (_user != null)
                {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, _user.Name),
                        new Claim(ClaimTypes.Email, _user.Email)
                        //new Claim("Email" , user.Email), //asi se pone cuando es un nombre adicional que se agrega 
                    };

                    var roles = await _service.GetUserRoles(_user.Id);
                    //se itera los roles porque tiene varios en este caso
                    foreach (var rol in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol.Role.Name));
                    }
                    

                    //TODO: logica para verificar si el usuario esta activo

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "BusinessUnit", new { UserId = _user.Id });
                }
                else
                {
                    userVM.Email = userVM.Email + " es Incorrecto o no existe";//TODO: no funciona
                    userVM.UsersQtity = await _service.UsersQtity();
                    return View(userVM); //TODO: corregir esto
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("BusinessUnitId");
            //HttpContext.Session.Remove("BusinessUnitId_Expiration");
            return RedirectToAction("Index", "Access");
        }

    }
}
