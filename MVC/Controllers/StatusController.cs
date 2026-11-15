using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STP.DataAccess;
using STP.Services;

namespace MVC.Controllers
{
    public class StatusController : Controller
    {
        private readonly StatusManager _estadoManager;

        public StatusController()
        {
            _estadoManager = new StatusManager();
        }

        public ActionResult Index()
        {
            var estados = _estadoManager.GetAllEstadosFromDataModel();
            return View(estados);
        }

        public ActionResult Details(int id)
        {
            var estado = _estadoManager.GetEstadoFromID(id);
            if (estado == null)
            {
                return HttpNotFound();
            }

            return View(estado);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(STP_ESTADO estado)
        {
            if (ModelState.IsValid)
            {

                _estadoManager.Add(estado);
                TempData["Mensaje"] = "Registro creado exitosamente";
                return RedirectToAction("Index");
            }

            return View(estado);
        }

        public ActionResult Edit(int id)
        {
            var estado = _estadoManager.GetEstadoFromID(id);
            if (estado == null)
            {
                return HttpNotFound();
            }

            return View(estado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(STP_ESTADO estado)
        {
            if (ModelState.IsValid)
            {

                var estadoInfoBase = _estadoManager.GetEstadoFromID(estado.ESTADO_ID);
                if (estadoInfoBase == null)
                {
                    return HttpNotFound();
                }

                estadoInfoBase.NOMBRE_ESTADO = estado.NOMBRE_ESTADO;

                _estadoManager.Update(estadoInfoBase);
                TempData["Mensaje"] = "Registro actualizado exitosamente";
                return RedirectToAction("Index");
            }

            return View(estado);
        }

        public ActionResult Delete(int id)
        {
            var estado = _estadoManager.GetEstadoFromID(id);
            if (estado == null)
            {
                return HttpNotFound();
            }

            return View(estado);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _estadoManager.Delete(id);
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