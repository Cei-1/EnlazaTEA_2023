using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Admin
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {

                    var query = context.ConsultarEspecialistasInactivos().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Especialista especialista = new ML.Especialista();
                            especialista.IdEspecialista = obj.IdEspecialista;
                            especialista.NoCedula = obj.NoCedula;
                            especialista.Usuario = new ML.Usuario();
                            especialista.Usuario.IdUsuario = obj.IdUsuario.Value;
                            especialista.Usuario.Nombre = obj.Nombre;
                            especialista.Usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            especialista.Usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            result.Objects.Add(especialista);
                        }

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
