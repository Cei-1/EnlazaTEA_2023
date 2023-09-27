using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Validacion(string email, string Contraseña)
        {
            if (email == "enlaza_tea_admi@enlaza.com" && Contraseña == "enlaza2023tea")
            {
                Session["SessionRol"] = 3;
                Session["SessionUsuario"] = 0;
                return View("Modal");
            }
            else
            {
                return View("Modal2");
            }

        }

        public ActionResult Especialistas()
        {
            var result = BL.Especialista.GetAll();

            if (result.Correct)
            {
                ML.Especialista especialista = new ML.Especialista();
                especialista.Especialistas = result.Objects;
                return View(especialista);
            }
            else
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                return View();
            }
        }

        public ActionResult Pacientes()
        {
            var result = BL.Paciente.GetAll();

            if (result.Correct)
            {
                ML.Paciente paciente = new ML.Paciente();
                paciente.Pacientes = result.Objects.Cast<ML.Paciente>().ToList();
                return View(paciente);
            }
            else
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            Session["SessionRol"] = null;
            Session["SessionUsuario"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ValidarCuentas()
        {
            ML.Result result = BL.Admin.GetAll();
            ML.Especialista especialista = new ML.Especialista();
            if (result.Correct)
            {
                especialista.Especialistas = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al traer los registros" + result.ErrorMessage;
            }

            return View(especialista);
        }

        public ActionResult CuentaValidada(int Id)
        {
            bool estatus = true;
            ML.Result result = new ML.Result();
            result = BL.Especialista.UpdateEstatus(Id, estatus);
            return View("Modal3");
        }
    }
}