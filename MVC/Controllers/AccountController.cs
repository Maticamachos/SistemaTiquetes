using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Mensaje =
                "Formulario validado. El inicio de sesión se conectará después.";

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Mensaje =
                "Formulario validado. La cuenta todavía no se ha guardado.";

            return View(model);
        }
    }
}