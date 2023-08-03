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


        [HttpPost]
        public ActionResult ActualizarEspecialista(ML.Especialista especialista)
        {
            int usuario_id = (int)Session["SessionUsuario"];

            // Setear el IdUsuario del especialista
            especialista.Usuario = new ML.Usuario { IdUsuario = usuario_id };

            ML.Result result = BL.Especialista.UpdateEF(especialista);
            if (result.Correct)
            {
                ML.Especialista especialistaActualizado = (ML.Especialista)result.Object;
                if (especialistaActualizado != null)
                {
                    // Actualizar los valores del especialista con los del objeto actualizado
                    especialista.Calle = especialistaActualizado.Calle;
                    especialista.NumeroExterno = especialistaActualizado.NumeroExterno;
                    especialista.NumeroInterno = especialistaActualizado.NumeroInterno;
                    especialista.Colonia = especialistaActualizado.Colonia;
                    especialista.Ciudad = especialistaActualizado.Ciudad;
                    especialista.Estado = especialistaActualizado.Estado;
                    especialista.CodigoPostal = especialistaActualizado.CodigoPostal;
                    especialista.Telefono = especialistaActualizado.Telefono;
                    especialista.Celular = especialistaActualizado.Celular;

                    // Redireccionar al método "Perfil" y pasar el objeto especialista actualizado
                    return RedirectToAction("Perfil", especialista);
                }
                else
                {
                    ViewBag.Mensaje = "No se ha podido actualizar el usuario.";
                }
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido actualizar el usuario. Error: " + result.ErrorMessage;
            }

            // Si ocurre un error, volver a mostrar la vista "Perfil" con el objeto especialista actual
            return View("Perfil", especialista);
        }


    }
}