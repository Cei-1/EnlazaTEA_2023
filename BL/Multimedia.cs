using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Multimedia
    {
        public static ML.Result GetAllWithLikes(int usuarioId)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    result.Objects = new List<object>();

                    // Obtener la lista de multimedia
                    var multimediaQuery = from multi in context.Multimedias
                                          select new ML.Multimedia
                                          {
                                              IdMultimedia = multi.IdMultimedia,
                                              Titulo = multi.Titulo,
                                              Contenido = multi.Contenido,
                                              Imagen = multi.Imagen,
                                              Tipo = multi.Tipo,
                                              VideoID = multi.VideoID,
                                              Audio = multi.Audio
                                          };

                    var multimediaList = multimediaQuery.ToList();

                    // Obtener la lista de likes relacionados al usuario actual
                    var likesQuery = from lk in context.Likes
                                     where lk.IdUsuario == usuarioId
                                     select new
                                     {
                                         IdMultimedia = lk.IdMultimedia,
                                         IdLike = lk.IdLike,
                                         IsLike = lk.IsLike
                                     };

                    var likesList = likesQuery.ToList();

                    // Combinar los resultados en una sola lista
                    foreach (var multimedia in multimediaList)
                    {
                        multimedia.Like = new ML.Like();
                        multimedia.Like.IdLike = likesList.FirstOrDefault(l => l.IdMultimedia == multimedia.IdMultimedia)?.IdLike ?? 0;
                        multimedia.Like.IsLike = likesList.FirstOrDefault(l => l.IdMultimedia == multimedia.IdMultimedia)?.IsLike ?? false;
                        multimedia.Like.UsuarioDioLike = multimedia.Like.IdLike != 0;
                        multimedia.Like.CantidadLikes = likesList.Count(l => l.IdMultimedia == multimedia.IdMultimedia && l.IsLike == true);
                    }

                    //multimedia.Like.CantidadLikes = query.Count(l => l.IdMultimedia == obj.IdMultimedia && l.IsLike == true);

                    result.Objects = multimediaList.Cast<object>().ToList();


                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetAllWithLikes()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    //var query = context.MultimediaGetAll().ToList();
                    var query = (from multi in context.Multimedias
                                 join lk in context.Likes on multi.IdMultimedia equals lk.IdMultimedia
                                 select new
                                 {
                                     IdMultimedia = multi.IdMultimedia,
                                     Titulo = multi.Titulo,
                                     Contenido = multi.Contenido,
                                     Imagen = multi.Imagen,
                                     Tipo = multi.Tipo,
                                     VideoID = multi.VideoID,
                                     Audio = multi.Audio,
                                     IdLike = lk.IdLike,
                                     IdUser = lk.IdUsuario,
                                     IsLike = lk.IsLike
                                 });

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        if (query.ToList().Count > 0)
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
                                multimedia.Like = new ML.Like();
                                multimedia.Like.IdLike = obj.IdLike;
                                multimedia.Like.IsLike = Convert.ToBoolean(obj.IsLike);
                                multimedia.Like.Usuario = new ML.Usuario();
                                multimedia.Like.Usuario.IdUsuario = obj.IdUser.Value;


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
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
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
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
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
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {

                    DL.Multimedia DLMultimedia = new DL.Multimedia();

                    DLMultimedia.Titulo = multimedia.Titulo;
                    DLMultimedia.Contenido = multimedia.Contenido;
                    DLMultimedia.Imagen = multimedia.Imagen;
                    DLMultimedia.Tipo = multimedia.Tipo;
                    DLMultimedia.VideoID = multimedia.VideoID;
                    DLMultimedia.Audio = multimedia.Audio;
                    DLMultimedia.IdUsuario = multimedia.Usuario.IdUsuario;

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
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
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
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
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
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.MultimediaGetByUser(IdUsuario).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        //ML.Multimedia multimedia = new ML.Multimedia();

                        //multimedia.IdMultimedia = query.IdMultimedia;
                        //multimedia.Titulo = query.Titulo;
                        //multimedia.Contenido = query.Contenido;
                        //multimedia.Imagen = query.Imagen;
                        //multimedia.Tipo = query.Tipo;
                        //multimedia.VideoID = query.VideoID;
                        //multimedia.Audio = query.Audio;
                        //multimedia.Usuario = new ML.Usuario();
                        //multimedia.Usuario.IdUsuario = query.IdUsuario.Value;

                        //result.Object = multimedia;//boxing

                        //result.Correct = true;

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
                            multimedia.Usuario = new ML.Usuario();
                            multimedia.Usuario.IdUsuario = obj.IdUsuario.Value;


                            result.Objects.Add(multimedia);
                        }
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

        public static ML.Result AgregarLike(int publicacionId, bool esLike, int usuarioId)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {

                    DL.Like DLLike = new DL.Like();

                    DLLike.IdUsuario = usuarioId;
                    DLLike.IdMultimedia = publicacionId;
                    DLLike.IsLike = esLike;

                    context.Likes.Add(DLLike);
                    int RowsAffected = context.SaveChanges();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo registrar el like";
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
        public static ML.Result UpdateLike(int IdMultimedia, bool IsLike, int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = (from likeDL in context.Likes
                                     //where likeDL.IdLike ==  likeUp.IdLike &&
                                 where likeDL.IdMultimedia == IdMultimedia &&
                                    likeDL.IdUsuario == IdUsuario
                                 select likeDL).SingleOrDefault();

                    if (query != null)
                    {
                        query.IsLike = IsLike;

                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el like";
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
        public static ML.Result GetLikesForMultimedia(int IdMultimedia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = (from likeDL in context.Likes
                                 where likeDL.IdMultimedia == IdMultimedia
                                 select likeDL).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Like likes = new ML.Like();

                        likes.IdLike = query.IdLike;
                        likes.IsLike = Convert.ToBoolean(query.IdLike);
                        likes.Multimedia = new ML.Multimedia();
                        likes.Multimedia.IdMultimedia = query.IdMultimedia.Value;
                        likes.Usuario = new ML.Usuario();
                        likes.Usuario.IdUsuario = query.IdUsuario.Value;

                        result.Object = likes;//boxing

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar los likes";
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
