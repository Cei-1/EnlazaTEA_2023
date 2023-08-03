using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Perfil()
        {
            int usuario_id = (int)Session["SessionUsuario"];
            ML.Especialista especialista = new ML.Especialista();
            ML.Result result = BL.Especialista.GetByIdEF(usuario_id);
            if (result.Correct)
            {
                especialista = (ML.Especialista)result.Object;
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al traer los registros: " + result.ErrorMessage;
            }
            return View(especialista);
        }

        public ActionResult ActualizarEspecialista()
        {
            int usuario_id = (int)Session["SessionUsuario"];
            ML.Especialista especialista = new ML.Especialista();
            ML.Result result = BL.Especialista.GetByIdEF(usuario_id);
            if (result.Correct)
            {
                especialista = (ML.Especialista)result.Object;
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al traer los registros: " + result.ErrorMessage;
            }

            return View(especialista);
        }

        [HttpPost]
        public ActionResult ActualizarEspecialista(ML.Especialista especialista)
        {
            if (ModelState.IsValid)
            {
                especialista.Usuario = new ML.Usuario();
                especialista.Usuario.IdUsuario = (int)Session["SessionUsuario"];
                ML.Result result = BL.Especialista.UpdateEF(especialista);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Perfil actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha podido actualizar. Error: " + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }



    }
}