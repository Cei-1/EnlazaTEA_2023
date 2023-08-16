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
        public ActionResult Perfil(int? IdUsuario)
        {
            int usuario_id;
            if (IdUsuario.HasValue)
            {
                usuario_id = IdUsuario.Value;
            }
            else
            {
                usuario_id = (int)Session["SessionUsuario"];
            }
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

        public ActionResult PerfilFamiliar()
        {
            int usuario_id = (int)Session["SessionUsuario"];
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetById(usuario_id);
            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al traer los registros: " + result.ErrorMessage;
            }
            return View(usuario);
        }

        [HttpGet]
        public ActionResult ActualizarPaciente()
        {
            int usuario_id = (int)Session["SessionUsuario"];
            ML.Paciente paciente = new ML.Paciente();
            ML.Result result = BL.Usuario.GetPacienteByIdUsuario(usuario_id);
            if (result.Correct)
            {
                paciente = (ML.Paciente)result.Object;
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al traer los registros: " + result.ErrorMessage;
            }

            return View(paciente);
        }

        [HttpPost]
        public ActionResult ActualizarPaciente(ML.Paciente paciente)
        {
            ML.Result result = BL.Usuario.UpdatePaciente(paciente);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Perfil actualizado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido actualizar. Error: " + result.ErrorMessage;
            }
            return PartialView("Modal2");
        }

        public ActionResult Especialistas()
        {
            var result = BL.Especialista.GetAll();

            if (result.Correct)
            {
                ML.Especialista especialista = new ML.Especialista();
                especialista.Especialistas = result.Objects; // Asegúrate de usar el tipo ML.Especialista aquí


                // Enviar el modelo Especialista a la vista
                return View(especialista);
            }
            else
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                return View();
            }
        }

        public ActionResult Agendar(int IdEspecialista)
        {
            int usuario_id = (int)Session["SessionUsuario"];
            ML.Cita cita = new ML.Cita();
            cita.Especialista = new ML.Especialista();
            cita.Especialista.IdEspecialista = IdEspecialista;
            cita.Usuario = new ML.Usuario();
            cita.Usuario.IdUsuario = usuario_id;
            return View(cita);
        }

        [HttpPost]
        public ActionResult AgregarCita(ML.Cita cita)
        {
            cita.Estatus = 1;
            try
            {
                // Aquí puedes realizar validaciones adicionales si es necesario
                // Por ejemplo, verificar que la fecha y el horario sean válidos

                // Llamar al método para agregar la cita en la capa de negocios
                ML.Result result = BL.Cita.Add(cita);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Cita agendada correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha podido agendar. Error: " + result.ErrorMessage;
                }
                return PartialView("Modal2");
                
                    // La cita se agregó correctamente, redirige a la página de perfil
         
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, mostrar el mensaje de error en la vista
                ViewBag.ErrorMessage = ex.Message;
                return View(cita);
            }
        }

        public ActionResult GetAllCitas()
        {
            int usuario_id = (int)Session["SessionUsuario"];
            var result = BL.Cita.GetCitasByUsuario(usuario_id);

            if (result.Correct)
            {
                ML.Cita cita = new ML.Cita();
                cita.Citas = result.Objects; // Asegúrate de usar el tipo ML.Especialista aquí


                // Enviar el modelo Especialista a la vista
                return View(cita);
            }
            else
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                return View();
            }
        }
    }
}