using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe;
using Stripe.Checkout;

namespace PL.Controllers
{
    public class PagoController : Controller
    {
        // GET: Pago
        public ActionResult Index()
        {
            ML.Membresia membresia = new ML.Membresia();
            ML.Result resultMembresia = BL.Membresia.GetAll();
            membresia.Membresias = resultMembresia.Objects;

            return View(membresia);
        }
        public ActionResult AddCart(int IdMembresia)
        {
            ML.Membresia membresia = new ML.Membresia();


            return RedirectToAction("CheckOut", "Pago", new { IdMembership = IdMembresia });
        }
        public ActionResult CheckOut(int IdMembership)
        {
            string stripeSecretKey = ConfigurationManager.AppSettings["Stripe:SecretKey"];

            // Configura la clave de la API de Stripe
            StripeConfiguration.ApiKey = stripeSecretKey;

            ML.Membresia membresia = new ML.Membresia();
            ML.Result resultMembresia = BL.Membresia.GetById(IdMembership);
            membresia.IdMembresia = ((ML.Membresia)resultMembresia.Object).IdMembresia;
            membresia.Nombre = ((ML.Membresia)resultMembresia.Object).Nombre;
            membresia.Precio = ((ML.Membresia)resultMembresia.Object).Precio;

            var domain = "https://localhost:44346/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"Pago/OrderConfirmation",
                CancelUrl = domain + "Pago/Failed",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                //CustomerEmail = "pachecoluis@gmail.com"
            };


            //item.SucursalProducto.Producto = new ML.Producto();

            var sessionListItems = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(membresia.Precio * 100),
                    Currency = "mxn",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = membresia.Nombre.ToString(),
                    }
                },
                Quantity = 1
            };
            options.LineItems.Add(sessionListItems);


            var service = new SessionService();
            Session session = service.Create(options);

            TempData["Session"] = session.Id;
            Response.Headers.Add("Location", session.Url);

            return new HttpStatusCodeResult(303);
        }
        public ActionResult OrderConfirmation()
        {
            var service = new SessionService();
            Session session = service.Get(TempData["Session"].ToString());
            if (session.PaymentStatus == "paid")
            {
                return View("Success");
            }

            return View("Failed");

        }
        public ActionResult Success()
        {
            return View();
        } 
        public ActionResult Failed()
        {
            return View();
        }
    }
}