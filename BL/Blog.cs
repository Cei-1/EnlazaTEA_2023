using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Blog
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.BlogGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Blog blog = new ML.Blog();
                            blog.IdBlog = obj.IdBlog;
                            blog.Titulo = obj.Titulo;
                            blog.Nombre = obj.Nombre;
                            blog.Descripcion = obj.Descripcion;
                            blog.Imagen = obj.Imagen;

                            result.Objects.Add(blog);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La Tabla Blog no contiene datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetById(int IdBlog)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.BlogGetById(IdBlog).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Blog blog = new ML.Blog();

                        blog.IdBlog = query.IdBlog;
                        blog.Titulo = query.Titulo;
                        blog.Nombre = query.Nombre;
                        blog.Descripcion = query.Descripcion;
                        blog.Imagen = query.Imagen;
                        result.Object = blog;//boxing

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar el blog";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Add(ML.Blog blog)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {

                    DL.Blog DLBlog = new DL.Blog();

                    DLBlog.Titulo = blog.Titulo;
                    DLBlog.Nombre = blog.Nombre;
                    DLBlog.Descripcion = blog.Descripcion;
                    DLBlog.Imagen = blog.Imagen;
                    DLBlog.IdUsuario = blog.Usuario.IdUsuario;

                    context.Blogs.Add(DLBlog);
                    int RowsAffected = context.SaveChanges();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo registrar el blog";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Update(ML.Blog blog)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.BlogUpdate(
                        blog.IdBlog,
                        blog.Titulo,
                        blog.Nombre,
                        blog.Descripcion,
                        blog.Imagen
                        );

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el blog";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(int IdBlog)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.BlogDelete(IdBlog);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static ML.Result GetByUser(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.BlogGetByUser(IdUsuario).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Blog blog = new ML.Blog();
                            blog.IdBlog = obj.IdBlog;
                            blog.Titulo = obj.Titulo;
                            blog.Nombre = obj.Nombre;
                            blog.Descripcion = obj.Descripcion;
                            blog.Imagen = obj.Imagen;
                            blog.Usuario = new ML.Usuario();
                            blog.Usuario.IdUsuario = obj.IdUsuario.Value;


                            result.Objects.Add(blog);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar el blog";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
