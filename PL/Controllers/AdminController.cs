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
    }
}