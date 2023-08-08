using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Multimedia
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = context.MultimediaGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Multimedia multimedia = new ML.Multimedia();
                            multimedia.IdMultimedia = obj.IdMultimedia;
                            multimedia.Titulo = obj.Titulo;
                            multimedia.Contenido = obj.Contenido;
                            multimedia.Imagen = obj.Imagen;
                            multimedia.Tipo = obj.Tipo;
                            multimedia.VideoID = obj.VideoID;
                            multimedia.Audio = obj.Audio;

                             
                            result.Objects.Add(multimedia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La Tabla multimedia no contiene datos";
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

        public static ML.Result GetById(int IdMultimedia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = context.MultimediaGetById(IdMultimedia).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Multimedia multimedia = new ML.Multimedia();

                        multimedia.IdMultimedia = query.IdMultimedia;
                        multimedia.Titulo = query.Titulo;
                        multimedia.Contenido = query.Contenido;
                        multimedia.Imagen = query.Imagen;
                        multimedia.Tipo = query.Tipo;
                        multimedia.VideoID = query.VideoID;
                        multimedia.Audio = query.Audio;

                        result.Object = multimedia;//boxing

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar la multimedia";
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

        public static ML.Result Add(ML.Multimedia multimedia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {

                    DL.Multimedia DLMultimedia = new DL.Multimedia();

                    DLMultimedia.Titulo = multimedia.Titulo;
                    DLMultimedia.Contenido = multimedia.Contenido;
                    DLMultimedia.Imagen = multimedia.Imagen;
                    DLMultimedia.Tipo = multimedia.Tipo;
                    DLMultimedia.VideoID = multimedia.VideoID;
                    DLMultimedia.Audio = multimedia.Audio;

                    context.Multimedias.Add(DLMultimedia);
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

        public static ML.Result Update(ML.Multimedia multimedia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = context.MultimediaUpdate(
                        multimedia.IdMultimedia,
                        multimedia.Titulo,
                        multimedia.Contenido,
                        multimedia.Imagen,
                        multimedia.Tipo,
                        multimedia.VideoID,
                        multimedia.Audio
                        );

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar la multimedia";
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

        public static ML.Result Delete(int IdMultimedia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = context.MultimediaDelete(IdMultimedia);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el multimedia";
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
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = context.MultimediaGetByUser(IdUsuario).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Multimedia multimedia = new ML.Multimedia();

                        multimedia.IdMultimedia = query.IdMultimedia;
                        multimedia.Titulo = query.Titulo;
                        multimedia.Contenido = query.Contenido;
                        multimedia.Imagen = query.Imagen;
                        multimedia.Tipo = query.Tipo;
                        multimedia.VideoID = query.VideoID;
                        multimedia.Audio = query.Audio;
                        multimedia.Usuario.IdUsuario = query.IdUsuario.Value;

                        result.Object = multimedia;//boxing

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar la multimedia";
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
