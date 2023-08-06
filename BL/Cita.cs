using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cita
    {
        public static Result Add(ML.Cita cita)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = context.AgregarCita(cita.Usuario.IdUsuario, cita.Especialista.IdEspecialista, cita.Fecha, cita.Horario, cita.Estatus);
                    if (query >= -1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar la cita.";
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

        public static Result GetCitasByEspecialista(int idEspecialista)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = context.BuscarCitasPorIdEspecialista(idEspecialista);

                    List<object> citas = new List<object>();
                    foreach (var item in query)
                    {
                        ML.Cita cita = new ML.Cita();
                        cita.IdCita = item.IdCita;
                        cita.Usuario = new ML.Usuario();
                        cita.Usuario.IdUsuario = item.IdUsuario.Value;
                        cita.Especialista = new ML.Especialista();
                        cita.Especialista.IdEspecialista = item.IdEspecialista.Value;
                        cita.Fecha = item.Fecha.Value;
                        cita.Horario = item.Horario.Value;
                        cita.Estatus = item.Estatus.Value;
                        citas.Add(cita);
                    }

                    result.Objects = citas;
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

        public static Result GetCitasByUsuario(int idUsuario)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = context.BuscarCitasPorIdUsuario(idUsuario);

                    List<object> citas = new List<object>();
                    foreach (var item in query)
                    {
                        ML.Cita cita = new ML.Cita();
                        cita.IdCita = item.IdCita;
                        cita.Usuario = new ML.Usuario();
                        cita.Usuario.IdUsuario = item.IdUsuario.Value;
                        cita.Especialista = new ML.Especialista();
                        cita.Especialista.IdEspecialista = item.IdEspecialista.Value;
                        cita.Fecha = item.Fecha.Value;
                        cita.Horario = item.Horario.Value;
                        cita.Estatus = item.Estatus.Value;
                        citas.Add(cita);
                    }

                    result.Objects = citas;
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

        public static Result UpdateStatus(int idCita, int estatus)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = context.ActualizarEstatusCita(idCita, estatus);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el estatus de la cita.";
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
