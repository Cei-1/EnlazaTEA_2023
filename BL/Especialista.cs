using ML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Especialista
    {
        public static Result Add(ML.Especialista especialista)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.AddEspecialista(especialista.NombreCarrera, especialista.NoCedula, especialista.Especialidad, especialista.Calle, especialista.NumeroExterno, especialista.NumeroInterno, especialista.Colonia, especialista.Ciudad, especialista.Estado, especialista.CodigoPostal, especialista.Telefono, especialista.Celular, especialista.Estatus, especialista.Usuario.IdUsuario);

                    if (query >= -1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "The user was not inserted";
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

        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    // Obtener los datos del especialista mediante el procedimiento almacenado
                    var especialistaDL = context.sp_BuscarEspecialistaPorIdUsuario(IdUsuario).SingleOrDefault();

                    if (especialistaDL != null)
                    {
                        ML.Especialista especialista = new ML.Especialista();
                        especialista.IdEspecialista = especialistaDL.IdEspecialista;
                        especialista.NombreCarrera = especialistaDL.NombreCarrera;
                        especialista.NoCedula = especialistaDL.NoCedula;
                        especialista.Especialidad = especialistaDL.Especialidad;
                        especialista.Calle = especialistaDL.Calle;
                        especialista.NumeroExterno = especialistaDL.NumeroExterno;
                        especialista.NumeroInterno = especialistaDL.NumeroInterno;
                        especialista.Colonia = especialistaDL.Colonia; // Nuevo campo Colonia
                        especialista.Ciudad = especialistaDL.Ciudad;
                        especialista.Estado = especialistaDL.Estado;
                        especialista.CodigoPostal = especialistaDL.CodigoPostal;
                        especialista.Telefono = especialistaDL.Telefono;
                        especialista.Celular = especialistaDL.Celular; // Nuevo campo Celular
                        especialista.Estatus = especialistaDL.Estatus.Value;
                        especialista.Usuario = new ML.Usuario();
                        especialista.Usuario.IdUsuario = especialistaDL.IdUsuario.Value;
                        especialista.Usuario.Nombre = especialistaDL.UsuarioNombre;
                        especialista.Usuario.ApellidoPaterno = especialistaDL.UsuarioApellidoPaterno;
                        especialista.Usuario.ApellidoMaterno = especialistaDL.UsuarioApellidoMaterno;
                        result.Object = especialista;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
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

        public static ML.Result GetIdMembresiaByEspecialistaId(int IdEspecialista)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    // Obtener el IdMembresia asociado al especialista desde la tabla Pago mediante LINQ
                    var idMembresia = (from p in context.Pagoes
                                       where p.Especialista.IdEspecialista == IdEspecialista
                                       select p.Membresia.IdMembresia).SingleOrDefault();

                    if (idMembresia != null)
                    {
                        result.Object = idMembresia;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el IdMembresia asociado al especialista.";
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

        // Método en la capa de lógica de negocios (BL)
        public static ML.Result UpdateCedula(ML.Especialista especialista)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    // Obtener el especialista mediante el IdUsuario
                    var especialistaDL = context.Especialistas
                        .FirstOrDefault(e => e.IdUsuario == especialista.Usuario.IdUsuario);

                    if (especialistaDL != null)
                    {
                        // Actualizar la cédula
                        especialistaDL.NoCedula = especialista.NoCedula;

                        // Guardar los cambios
                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el especialista asociado al usuario.";
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

        public static ML.Result UpdateEF(ML.Especialista especialista)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var updateResult = context.ActualizarPerfilEspecialista(especialista.Usuario.IdUsuario, especialista.Calle, especialista.NumeroExterno, especialista.NumeroInterno, especialista.Ciudad, especialista.Estado, especialista.CodigoPostal, especialista.Telefono, especialista.Colonia, especialista.Celular);

                    if (updateResult >= 1)
                    {
                        result = GetByIdEF(especialista.Usuario.IdUsuario);
                        ///especialista = (ML.Especialista)result.Object;
                        //result.Object = especialista;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = result.ErrorMessage;
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
            result.Objects = new List<object>();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.GetAllEspecialistas();

                    foreach (var item in query)
                    {
                        ML.Especialista especialista = new ML.Especialista();
                        especialista.IdEspecialista = item.IdEspecialista;
                        especialista.NombreCarrera = item.NombreCarrera;
                        especialista.NoCedula = item.NoCedula;
                        especialista.Especialidad = item.Especialidad;
                        especialista.Calle = item.Calle;
                        especialista.NumeroExterno = item.NumeroExterno;
                        especialista.NumeroInterno = item.NumeroInterno;
                        especialista.Colonia = item.Colonia;
                        especialista.Ciudad = item.Ciudad;
                        especialista.Estado = item.Estado;
                        especialista.CodigoPostal = item.CodigoPostal;
                        especialista.Telefono = item.Telefono;
                        especialista.Celular = item.Celular;

                        especialista.Usuario = new ML.Usuario();
                        especialista.Usuario.IdUsuario = item.IdUsuario;
                        especialista.Usuario.Nombre = item.Nombre;
                        especialista.Usuario.ApellidoPaterno = item.ApellidoPaterno;
                        especialista.Usuario.ApellidoMaterno = item.ApellidoMaterno;
                        especialista.Usuario.Email = item.Email;
                        especialista.Usuario.Contraseña = item.Contraseña;

                        result.Objects.Add(especialista);
                    }

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
        public static ML.Result UpdateEstatus(int Id, bool estatus)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    // Buscar el paciente por su ID
                    var especialista = context.Especialistas.SingleOrDefault(p => p.IdEspecialista == Id);

                    if (especialista != null)
                    {
                        // Actualizar el campo Evaluacion
                        especialista.Estatus = estatus;
                        context.SaveChanges(); // Guardar los cambios en la base de datos
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Paciente no encontrado";
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
