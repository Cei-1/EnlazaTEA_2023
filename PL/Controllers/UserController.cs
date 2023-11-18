using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        public ActionResult ActualizarCedula(ML.Especialista especialista)
        {
            especialista.Usuario = new ML.Usuario();
            especialista.Usuario.IdUsuario = (int)Session["SessionUsuario"];

            ML.Result result = BL.Especialista.UpdateCedula(especialista);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Perfil actualizado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido actualizar. Error: " + result.ErrorMessage;
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
            cita.Observacion = "Ninguna";
            try
            {

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

        public ActionResult CancelarCita(int idcita)
        {
            var result = BL.Cita.CancelarCitasByUsuario(idcita);

            if (result.Correct)
            {
                TempData["SuccessMessage"] = "Citas canceladas exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al cancelar citas: " + result.ErrorMessage;
            }

            return RedirectToAction("GetAllCitas"); // Redireccionar a la acción GetAllCitas
        }

        public ActionResult CancelarCitaEspecialista(int idcita)
        {
            var result = BL.Cita.CancelarCitasByUsuario(idcita);

            if (result.Correct)
            {
                TempData["SuccessMessage"] = "Citas canceladas exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al cancelar citas: " + result.ErrorMessage;
            }

            return RedirectToAction("GetAllCitasEspecilistas"); // Redireccionar a la acción GetAllCitas
        }

        public ActionResult EliminarCita(int idcita)
        {
            var result = BL.Cita.EliminarCitasByUsuario(idcita);

            if (result.Correct)
            {
                TempData["SuccessMessage"] = "Citas canceladas exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al cancelar citas: " + result.ErrorMessage;
            }

            return RedirectToAction("GetAllCitasEspecilistas"); // Redireccionar a la acción GetAllCitas
        }

        public ActionResult EliminarCitaPaciente(int idcita)
        {
            var result = BL.Cita.EliminarCitasByUsuario(idcita);

            if (result.Correct)
            {
                TempData["SuccessMessage"] = "Citas canceladas exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al cancelar citas: " + result.ErrorMessage;
            }

            return RedirectToAction("GetAllCitas"); // Redireccionar a la acción GetAllCitas
        }

        public ActionResult Rechazar(int idcita)
        {
            var result = BL.Cita.RechazarCitasByUsuario(idcita);

            if (result.Correct)
            {
                TempData["SuccessMessage"] = "Citas canceladas exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al cancelar citas: " + result.ErrorMessage;
            }

            return RedirectToAction("GetAllCitasEspecilistas"); // Redireccionar a la acción GetAllCitas
        }

        public ActionResult Aceptar(int idcita)
        {
            var result = BL.Cita.AceptarCitasByUsuario(idcita);

            if (result.Correct)
            {
                TempData["SuccessMessage"] = "Citas canceladas exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al cancelar citas: " + result.ErrorMessage;
            }

            return RedirectToAction("GetAllCitasEspecilistas"); // Redireccionar a la acción GetAllCitas
        }

        public ActionResult LLamada(int idCita, string url)
        {
            // Llama al método en la capa de lógica de negocio para realizar la acción necesaria
            var result = BL.Cita.LLamada(idCita, url);

            if (result.Correct)
            {
                TempData["SuccessMessage"] = "Llamada realizada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al realizar la llamada: " + result.ErrorMessage;
            }

            return RedirectToAction("GetAllCitasEspecilistas"); // Redireccionar a la acción GetAllCitasEspecilistas
        }


        public ActionResult GetAllCitasEspecilistas()
        {
            int usuario_id = (int)Session["SessionUsuario"];
            var resultespceialista = BL.Especialista.GetByIdEF(usuario_id);
            ML.Especialista especialista = new ML.Especialista();
            especialista = (ML.Especialista)resultespceialista.Object;
            var result = BL.Cita.GetCitasByEspecialista(especialista.IdEspecialista);

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

        public ActionResult VerCita(int idCita)
        {
            Session["SessionCita"] = idCita;
            var resultCita = BL.Cita.GetCitaById(idCita);

            if (resultCita.Correct)
            {
                ML.Cita cita = (ML.Cita)resultCita.Object;

                // Pasar el objeto Cita a la vista
                return View(cita);
            }
            else
            {
                ViewBag.ErrorMessage = resultCita.ErrorMessage;
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddDetalles(int IdCita, string Observaciones, int Nivel, int IdFamiliar)
        {

                // Llamar al método de la capa de negocios para actualizar los detalles de la cita
                var resultUpdateDetalles = BL.Cita.AddDetalles(IdCita, Observaciones);
            var resultUpdateNTDA = BL.Paciente.UpdateNivel(IdFamiliar, Nivel);

                if (resultUpdateDetalles.Correct)
                {
                var result = BL.Cita.CompletarCitasByUsuario(IdCita);
                    TempData["SuccessMessage"] = "Observaciones guardadas exitosamente.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error al guardar observaciones: " + resultUpdateDetalles.ErrorMessage;
                }

                return RedirectToAction("GetAllCitasEspecilistas");
            
        }
        public ActionResult Evaluacion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEvaluacion(int Calificacion)
        {
            int usuario_id = (int)Session["SessionUsuario"];
            ML.Result result = new ML.Result();
            result = BL.Paciente.AddEvaluacion(usuario_id, Calificacion);
            return Json(new { success = true });
        }

        public ActionResult HistorialMedico(int IdUsuario)
        {
            var result = BL.Cita.GetCitasByUsuario(IdUsuario);

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

        [HttpPost]
        public ActionResult UpdateImagen()
        {
            try
            {
                // Verificar si hay un archivo en la solicitud
                if (Request.Files.Count > 0)
                {
                    // Obtener el archivo de la solicitud
                    HttpPostedFileBase file = Request.Files[0];

                    // Verificar si el archivo no está vacío
                    if (file != null && file.ContentLength > 0)
                    {
                        int IdUsuario = (int)Session["SessionUsuario"];

                        // Obtener la extensión del archivo
                        string extension = Path.GetExtension(file.FileName);

                        // Construir el nombre del archivo utilizando el IdUsuario y la extensión
                        string fileName = $"{IdUsuario}{extension}";

                        // Obtener la ruta completa del archivo en la carpeta "Image" del proyecto
                        string filePath = Path.Combine(Server.MapPath("~/Image/"), fileName);

                        // Guardar el archivo en la carpeta "Image"
                        file.SaveAs(filePath);

                        // Actualizar la referencia de la imagen en la base de datos
                        ML.Result result = BL.Usuario.UpdateImagen(IdUsuario, fileName);

                        // Retornar el resultado exitoso
                        return Json(new { success = true });
                    }
                }

                // Retornar un mensaje de error si no se proporcionó una imagen
                return Json(new { success = false, error = "No se proporcionó una imagen válida." });
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y retornar un mensaje de error
                return Json(new { success = false, error = "Error al procesar la imagen: " + ex.Message });
            }
        }

    }
}