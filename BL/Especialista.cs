using ML;
using System;
using System.Collections.Generic;
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
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = context.AddEspecialista(especialista.NombreCarrera,especialista.NoCedula,especialista.Especialidad,especialista.Calle,especialista.NumeroExterno,especialista.NumeroInterno,especialista.Colonia,especialista.Ciudad,especialista.Estado,especialista.CodigoPostal,especialista.Telefono,especialista.Celular,especialista.Estatus,especialista.Usuario.IdUsuario);

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
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
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

    }
}
