using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            ML.Blog blog = new ML.Blog();

            ML.Result resultBlog = BL.Blog.GetAll();

            blog.Blogs = resultBlog.Objects;

            return View(blog);
        }

        public ActionResult GetAll()
        {
            ML.Blog blog = new ML.Blog();

            ML.Result resultBlog = BL.Blog.GetAll();

            blog.Blogs = resultBlog.Objects;

            return View(blog);
        }

        [HttpGet] //Mostrar formulario
        public ActionResult Form(int? IdBlog)
        {
            ML.Blog blog = new ML.Blog();
            
            if (IdBlog == null)
            {
                return View(blog);
            }
            else
            {
                ML.Result result = BL.Blog.GetById(IdBlog.Value);

                blog.IdBlog = ((ML.Blog)result.Object).IdBlog;
                blog.Titulo = ((ML.Blog)result.Object).Titulo;
                blog.Nombre = ((ML.Blog)result.Object).Nombre;
                blog.Descripcion = ((ML.Blog)result.Object).Descripcion;
                blog.Imagen = ((ML.Blog)result.Object).Imagen;
                return View(blog);

            }
        }

        [HttpPost] //Recibe datos del formulario
        public ActionResult Form(ML.Blog blog, HttpPostedFileBase imgBlog)
        {
            if (imgBlog != null)
            {
                blog.Imagen = ConvertToBytes(imgBlog);
            }

            if (blog.IdBlog == 0)//add
            {
                ML.Result result = BL.Blog.Add(blog);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha registrado correctamente el Articulo";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha registado correctamente el articulo " + result.ErrorMessage;
                }
            }
            else //update
            {
                ML.Result result = BL.Blog.Update(blog);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha actualizado correctamente el articulo";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha podido actualizar conrrectamente el articulo " + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdBlog)
        {
            ML.Result result = BL.Blog.Delete(IdBlog);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado correctamente el articulo";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido eliminar la articulo. Error: " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        public ActionResult GetArticuloById(int IdBlog)
        {
            ML.Blog blog = new ML.Blog();

            ML.Result result = BL.Blog.GetById(IdBlog);

            blog.IdBlog = ((ML.Blog)result.Object).IdBlog;
            blog.Titulo = ((ML.Blog)result.Object).Titulo;
            blog.Nombre = ((ML.Blog)result.Object).Nombre;
            blog.Descripcion = ((ML.Blog)result.Object).Descripcion;
            blog.Imagen = ((ML.Blog)result.Object).Imagen;
            // Agregar los datos a ViewBag
            ViewBag.Titulo = blog.Titulo;
            ViewBag.Nombre = blog.Nombre;
            ViewBag.Descripcion = blog.Descripcion;

            // Validación para la imagen
            if (blog.Imagen != null && blog.Imagen.Length > 0)
            {
                ViewBag.Imagen = "data:image/jpg;base64," + Convert.ToBase64String(blog.Imagen);
            }
            else
            {
                // Ruta de la imagen por defecto si no hay imagen
                ViewBag.Imagen = Url.Content("~/Content/Images/bg-inicio-1.jpg");
            }
            //ViewBag.Imagen = "data:image/jpg;base64," + Convert.ToBase64String(blog.Imagen);


            return PartialView("ModalArticulo");
        }

        /**Convertir img a bytes**/
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}