using STP.DataAccess;
using STP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RolSController : Controller
    {
        private readonly RolManager _rolManager;

        public RolSController()
        {
            _rolManager = new RolManager();
        }

        public ActionResult Index()
        {
            var roles = _rolManager.GetAllRolesFromDataModel();
            return View(roles);
        }

        public ActionResult Details(int id)
        {
            var rol = _rolManager.GetRolFromID(id);
            if (rol == null)
            {
                return HttpNotFound();
            }

            return View(rol);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(STP_ROL rol)
        {
            if (ModelState.IsValid)
            {

                _rolManager.Add(rol);
                TempData["Mensaje"] = "Registro creado exitosamente";
                return RedirectToAction("Index");
            }

            return View(rol);
        }

        public ActionResult Edit(int id)
        {
            var rol = _rolManager.GetRolFromID(id);
            if (rol == null)
            {
                return HttpNotFound();
            }

            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(STP_ROL rol)
        {
            if (ModelState.IsValid)
            {

                var rolInfoBase = _rolManager.GetRolFromID(rol.ROL_ID);
                if (rolInfoBase == null)
                {
                    return HttpNotFound();
                }

                rolInfoBase.NOMBRE = rol.NOMBRE;
                rolInfoBase.DESCRIPCION = rol.DESCRIPCION;

                _rolManager.Update(rolInfoBase);
                TempData["Mensaje"] = "Registro actualizado exitosamente";
                return RedirectToAction("Index");
            }

            return View(rol);
        }

        public ActionResult Delete(int id)
        {
            var rol = _rolManager.GetRolFromID(id);
            if (rol == null)
            {
                return HttpNotFound();
            }

            return View(rol);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _rolManager.Delete(id);
                TempData["Mensaje"] = "Registro eliminado exitosamente";
            }
            catch (Exception)
            {
                TempData["Error"] = "No se pudo eliminar el registro porque está siendo utilizado por otros registros.";
            }
            return RedirectToAction("Index");
        }
    }
}