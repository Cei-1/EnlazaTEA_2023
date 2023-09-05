using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MultimediaController : Controller
    {
        // GET: Multimedia
        public ActionResult Index()
        {
            ML.Multimedia multimedia = new ML.Multimedia();
            int usuarioId = (int)Session["SessionUsuario"];
            ML.Result resultMultimedia = BL.Multimedia.GetAllWithLikes(usuarioId);
            multimedia.Multimedias = resultMultimedia.Objects;

            return View(multimedia);
        }

        public ActionResult GetAll()
        {
            ML.Multimedia multimedia = new ML.Multimedia();
            int usuarioId = (int)Session["SessionUsuario"];


            ML.Result resultMultimedia = BL.Multimedia.GetByUser(usuarioId);

            multimedia.Multimedias = resultMultimedia.Objects;

            return View(multimedia);

        }

        [HttpGet]
        public ActionResult Form(int? IdMultimedia)
        {
            ML.Multimedia multimedia = new ML.Multimedia();

            if (IdMultimedia == null)
            {
                return View(multimedia);
            }
            else
            {
                ML.Result result = BL.Multimedia.GetById(IdMultimedia.Value);
                multimedia.IdMultimedia = ((ML.Multimedia)result.Object).IdMultimedia;
                multimedia.Titulo = ((ML.Multimedia)result.Object).Titulo;
                multimedia.Contenido = ((ML.Multimedia)result.Object).Contenido;
                multimedia.Imagen = ((ML.Multimedia)result.Object).Imagen;
                multimedia.Tipo = ((ML.Multimedia)result.Object).Tipo;
                multimedia.VideoID = ((ML.Multimedia)result.Object).VideoID;
                multimedia.Audio = ((ML.Multimedia)result.Object).Audio;
                return View(multimedia);

            }
        }

        [HttpPost] //Recibe datos del formulario
        public ActionResult Form(ML.Multimedia multimedia, HttpPostedFileBase imgMultimedia, HttpPostedFileBase audioFile)
        {
            if (imgMultimedia != null)
            {
                multimedia.Imagen = ConvertToBytes(imgMultimedia);
            }
            if (audioFile != null)
            {
                multimedia.Audio = ConvertToBytes(audioFile);
            }
            multimedia.Usuario = new ML.Usuario();
            multimedia.Usuario.IdUsuario = (int)Session["SessionUsuario"];
            if (multimedia.IdMultimedia == 0)//add
            {
                ML.Result result = BL.Multimedia.Add(multimedia);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha registrado correctamente la multimedia";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha registado correctamente la multimedia " + result.ErrorMessage;
                }
            }
            else //update
            {
                ML.Result result = BL.Multimedia.Update(multimedia);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha actualizado correctamente la multimedia";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha podido actualizar correctamente la multimedia " + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdMultimedia)
        {
            ML.Result result = BL.Multimedia.Delete(IdMultimedia);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado correctamente la multimedia";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido eliminar la multimedia. Error: " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        public ActionResult GetMultimediaById(int IdMultimedia)
        {
            ML.Multimedia multimedia = new ML.Multimedia();

            ML.Result result = BL.Multimedia.GetById(IdMultimedia);

            multimedia.IdMultimedia = ((ML.Multimedia)result.Object).IdMultimedia;
            multimedia.Titulo = ((ML.Multimedia)result.Object).Titulo;
            multimedia.Contenido = ((ML.Multimedia)result.Object).Contenido;
            multimedia.Imagen = ((ML.Multimedia)result.Object).Imagen;
            multimedia.Tipo = ((ML.Multimedia)result.Object).Tipo;
            multimedia.VideoID = ((ML.Multimedia)result.Object).VideoID;
            multimedia.Audio = ((ML.Multimedia)result.Object).Audio;
            // Agregar los datos a ViewBag
            ViewBag.Titulo = multimedia.Titulo;
            ViewBag.Nombre = multimedia.Contenido;

            // Validación para la imagen
            if (multimedia.Imagen != null && multimedia.Imagen.Length > 0)
            {
                ViewBag.Imagen = "data:image/jpg;base64," + Convert.ToBase64String(multimedia.Imagen);
            }
            else
            {
                // Ruta de la imagen por defecto si no hay imagen
                ViewBag.Imagen = Url.Content("~/Content/Images/bg-inicio-1.jpg");
            }

            if (multimedia.Tipo == "Video")
            {
                ViewBag.VideoID = multimedia.VideoID;
            }
            else
            {
                // Validación para el audio
                if (multimedia.Audio != null && multimedia.Audio.Length > 0)
                {
                    ViewBag.Audio = "data:audio/mp3;base64," + Convert.ToBase64String(multimedia.Audio);
                }
                else
                {
                    // Ruta de la imagen por defecto si no hay audio
                    ViewBag.Imagen = Url.Content("~/Content/Images/bg-inicio-1.jpg");
                }
            }

            return PartialView("ModalMultimedia");
        }

        /**Convertir img a bytes**/
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        /**Likes*/
        public ActionResult AgregarLike(int IdMultimedia, bool esLike, int IdLike)
        {
            int usuarioId = (int)Session["SessionUsuario"];

            if (IdLike == 0)//add
            {
                ML.Result result = BL.Multimedia.AgregarLike(IdMultimedia, esLike, usuarioId);
                if (result.Correct)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    return RedirectToAction("Ver", new { id = IdMultimedia });
                }
            }
            else//else
            {
                ML.Result result = BL.Multimedia.UpdateLike(IdMultimedia, esLike, usuarioId);
                if (result.Correct)
                {
                    return RedirectToAction("Index", new { id = IdMultimedia });
                }
                else
                {
                    // Manejar el caso de error
                    return RedirectToAction("Ver", new { id = IdMultimedia });
                }
            }
        }

    }
}