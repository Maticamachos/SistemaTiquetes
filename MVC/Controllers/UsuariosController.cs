using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly PAP_TICKETSG8Entities db =
            new PAP_TICKETSG8Entities();

        // Listado de usuarios.
        public ActionResult Index()
        {
            var usuarios = db.STP_USUARIO
                .Include(u => u.STP_ROL)
                .Include(u => u.STP_ESTADO)
                .OrderBy(u => u.NOMBRE)
                .ThenBy(u => u.PRIMER_APELLIDO)
                .ToList();

            return View(usuarios);
        }

        // Formulario de registro.
        [HttpGet]
        public ActionResult Create()
        {
            var formulario = new CrearUsuarioViewModel();

            CargarOpciones(formulario);

            return View(formulario);
        }

        // Recoge y guarda los datos del formulario.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CrearUsuarioViewModel formulario)
        {
            if (formulario.RolId.HasValue &&
                !db.STP_ROL.Any(r => r.ROL_ID == formulario.RolId.Value))
            {
                ModelState.AddModelError(
                    "RolId",
                    "El rol seleccionado no existe.");
            }

            if (formulario.EstadoId.HasValue &&
                !db.STP_ESTADO.Any(e => e.ESTADO_ID == formulario.EstadoId.Value))
            {
                ModelState.AddModelError(
                    "EstadoId",
                    "El estado seleccionado no existe.");
            }

            if (!ModelState.IsValid)
            {
                CargarOpciones(formulario);
                return View(formulario);
            }

            var usuario = new STP_USUARIO
            {
                NOMBRE = formulario.Nombre.Trim(),
                PRIMER_APELLIDO = formulario.PrimerApellido.Trim(),
                SEGUNDO_APELLIDO = formulario.SegundoApellido.Trim(),
                CORREO = formulario.Correo.Trim(),
                ROL_ID = formulario.RolId.Value,
                ESTADO_ID = formulario.EstadoId.Value,
                ULTIMO_INICIO_SESION = null
            };

            db.STP_USUARIO.Add(usuario);
            db.SaveChanges();

            TempData["Mensaje"] = "Usuario registrado correctamente.";

            return RedirectToAction("Index");
        }

        // Abre el formulario con los datos del usuario.
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(
                    System.Net.HttpStatusCode.BadRequest);
            }

            var usuario = db.STP_USUARIO.Find(id.Value);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            var formulario = new EditarUsuarioViewModel
            {
                UsuarioId = usuario.USUARIO_ID,
                Nombre = usuario.NOMBRE,
                PrimerApellido = usuario.PRIMER_APELLIDO,
                SegundoApellido = usuario.SEGUNDO_APELLIDO,
                Correo = usuario.CORREO,
                RolId = usuario.ROL_ID,
                EstadoId = usuario.ESTADO_ID
            };

            CargarOpciones(formulario);

            return View(formulario);
        }

        // Guarda los cambios del usuario.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, EditarUsuarioViewModel formulario)
        {
            if (!id.HasValue || id.Value != formulario.UsuarioId)
            {
                return new HttpStatusCodeResult(
                    System.Net.HttpStatusCode.BadRequest);
            }

            var usuario = db.STP_USUARIO.Find(id.Value);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            if (formulario.RolId.HasValue &&
                !db.STP_ROL.Any(r => r.ROL_ID == formulario.RolId.Value))
            {
                ModelState.AddModelError(
                    "RolId",
                    "El rol seleccionado no existe.");
            }

            if (formulario.EstadoId.HasValue &&
                !db.STP_ESTADO.Any(e => e.ESTADO_ID == formulario.EstadoId.Value))
            {
                ModelState.AddModelError(
                    "EstadoId",
                    "El estado seleccionado no existe.");
            }

            if (!ModelState.IsValid)
            {
                CargarOpciones(formulario);
                return View(formulario);
            }

            usuario.NOMBRE = formulario.Nombre.Trim();
            usuario.PRIMER_APELLIDO = formulario.PrimerApellido.Trim();
            usuario.SEGUNDO_APELLIDO = formulario.SegundoApellido.Trim();
            usuario.CORREO = formulario.Correo.Trim();
            usuario.ROL_ID = formulario.RolId.Value;
            usuario.ESTADO_ID = formulario.EstadoId.Value;

            db.SaveChanges();

            TempData["Mensaje"] = "Usuario actualizado correctamente.";

            return RedirectToAction("Index");
        }   

        // Prepara las opciones desplegables.
        private void CargarOpciones(CrearUsuarioViewModel formulario)
        {
            ViewBag.Roles = new SelectList(
                db.STP_ROL.OrderBy(r => r.NOMBRE).ToList(),
                "ROL_ID",
                "NOMBRE",
                formulario.RolId);

            ViewBag.Estados = new SelectList(
                db.STP_ESTADO.OrderBy(e => e.NOMBRE_ESTADO).ToList(),
                "ESTADO_ID",
                "NOMBRE_ESTADO",
                formulario.EstadoId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}