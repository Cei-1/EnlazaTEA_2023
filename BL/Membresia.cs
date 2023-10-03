using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Membresia
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = (from membresia in context.Membresias
                                 select new
                                 {
                                     IdMembresia = membresia.IdMembresia,
                                     Nombre = membresia.Nombre,
                                     Precio = membresia.Precio
                                 });

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Membresia membresia = new ML.Membresia();
                            membresia.IdMembresia = obj.IdMembresia;
                            membresia.Nombre = obj.Nombre;
                            membresia.Precio = obj.Precio;


                            result.Objects.Add(membresia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La Tabla membresia no contiene datos";
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

        public static ML.Result GetById(int IdMembresia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = (from membresia in context.Membresias
                                 where membresia.IdMembresia == IdMembresia
                                 select new
                                 {
                                     IdMembresia = membresia.IdMembresia,
                                     Nombre = membresia.Nombre,
                                     Precio = membresia.Precio
                                 }).FirstOrDefault();


                    if (query != null)
                    {
                        
                            ML.Membresia membresia = new ML.Membresia();
                            membresia.IdMembresia = query.IdMembresia;
                            membresia.Nombre = query.Nombre;
                            membresia.Precio = query.Precio;


                            result.Object = membresia;
                        
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La Tabla membresia no contiene datos";
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
                    var query = (from membresia in context.Membresias
                                 join pago  in context.Pagoes on membresia.IdMembresia equals pago.IdMembresia
                                 join especialista  in context.Especialistas on pago.IdEspecialista equals especialista.IdEspecialista
                                 join usuario  in context.Usuarios on especialista.IdUsuario equals usuario.IdUsuario
                                 where especialista.IdEspecialista == IdUsuario
                                 select new
                                 {
                                     IdMembresia = membresia.IdMembresia,
                                     Nombre = membresia.Nombre,
                                     Precio = membresia.Precio
                                 }).FirstOrDefault();


                    if (query != null)
                    {
                        
                            ML.Membresia membresia = new ML.Membresia();
                            membresia.IdMembresia = query.IdMembresia;
                            membresia.Nombre = query.Nombre;
                            membresia.Precio = query.Precio;


                            result.Object = membresia;
                        
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La Tabla membresia no contiene datos";
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
