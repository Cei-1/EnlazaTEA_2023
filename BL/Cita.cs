using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
                    var newCita = new DL.Cita
                    {
                        IdUsuario = cita.Usuario.IdUsuario,
                        IdEspecialista = cita.Especialista.IdEspecialista,
                        Fecha = cita.Fecha,
                        Horario = cita.Horario,
                        Estatus = cita.Estatus,
                        Virtual = cita.Virtual, // Asegúrate de que el modelo ML.Cita tenga la propiedad Virtual
                        Observacion = cita.Observacion
                    };

                    context.Citas.Add(newCita);
                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
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
                    var query = from cita in context.Citas
                                join paciente in context.Pacientes on cita.Usuario.IdUsuario equals paciente.Usuario.IdUsuario
                                where cita.IdEspecialista == idEspecialista
                                select new
                                {
                                    cita.IdCita,
                                    cita.IdUsuario,
                                    cita.IdEspecialista,
                                    cita.Fecha,
                                    cita.Horario,
                                    cita.Estatus,
                                    cita.Virtual,
                                    cita.Link,
                                    paciente.Nombre,
                                    paciente.ApellidoPaterno,
                                    paciente.ApellidoMaterno

                                };

                    List<object> citas = new List<object>();
                    foreach (var item in query)
                    {
                        ML.Cita cita = new ML.Cita();
                        cita.IdCita = item.IdCita;
                        cita.Usuario = new ML.Usuario();
                        cita.Link = item.Link;
                        cita.Virtual = item.Virtual.Value;
                        cita.Usuario.IdUsuario = item.IdUsuario.Value;
                        cita.Usuario.Paciente = new ML.Paciente();
                        cita.Usuario.Paciente.Nombre = item.Nombre;
                        cita.Usuario.Paciente.ApellidoPaterno = item.ApellidoPaterno;
                        cita.Usuario.Paciente.ApellidoMaterno = item.ApellidoMaterno;
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
                    var query = from cita in context.Citas
                                join especialista in context.Especialistas on cita.IdEspecialista equals especialista.IdEspecialista
                                where cita.IdUsuario == idUsuario
                                select new
                                {
                                    cita.IdCita,
                                    cita.IdUsuario,
                                    cita.IdEspecialista,
                                    cita.Fecha,
                                    cita.Horario,
                                    cita.Estatus,
                                    cita.Virtual, 
                                    cita.Link,
                                    cita.Observacion,
                                    especialista.Usuario.Nombre,
                                    especialista.Usuario.ApellidoPaterno,
                                    especialista.Usuario.ApellidoMaterno
                                };

                    List<object> citas = new List<object>();
                    foreach (var item in query)
                    {
                        ML.Cita cita = new ML.Cita();
                        cita.IdCita = item.IdCita;
                        cita.Usuario = new ML.Usuario();
                        cita.Usuario.IdUsuario = item.IdUsuario.Value;
                        cita.Especialista = new ML.Especialista();
                        cita.Especialista.IdEspecialista = item.IdEspecialista.Value;
                        cita.Especialista.Usuario = new ML.Usuario();
                        cita.Especialista.Usuario.Nombre = item.Nombre;
                        cita.Especialista.Usuario.ApellidoPaterno = item.ApellidoPaterno;
                        cita.Especialista.Usuario.ApellidoMaterno = item.ApellidoMaterno;
                        cita.Virtual = item.Virtual.Value;
                        cita.Detalles = new ML.DetallesCita();
                        cita.Observacion = item.Observacion;
                        cita.Link = item.Link;
                        cita.Fecha = item.Fecha.Value.Date;

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

        public static Result CancelarCitasByUsuario(int idCita)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var citas = context.Citas.Where(cita => cita.IdCita == idCita); // Obtener citas no canceladas del usuario

                    foreach (var cita in citas)
                    {
                        cita.Estatus = 4; // Cambiar el estatus a "Rechazada"
                    }

                    context.SaveChanges(); // Guardar cambios en la base de datos
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

        public static Result EliminarCitasByUsuario(int idCita)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var cita = context.Citas.FirstOrDefault(c => c.IdCita == idCita); // Buscar la cita por su IdCita

                    if (cita != null)
                    {
                        context.Citas.Remove(cita); // Eliminar la cita de la base de datos
                        context.SaveChanges(); // Guardar cambios en la base de datos
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró la cita con el ID especificado.";
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

        public static Result RechazarCitasByUsuario(int idCita)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var citas = context.Citas.Where(cita => cita.IdCita == idCita); // Obtener citas no canceladas del usuario

                    foreach (var cita in citas)
                    {
                        cita.Estatus = 3;
                        cita.Observacion = "Lo lamento pero no estare disponible en este horario";
                    }

                    context.SaveChanges(); // Guardar cambios en la base de datos
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
        public static Result AceptarCitasByUsuario(int idCita)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var citas = context.Citas.Where(cita => cita.IdCita == idCita); // Obtener citas no canceladas del usuario

                    foreach (var cita in citas)
                    {
                        cita.Estatus = 2; // Cambiar el estatus a "Rechazada"
                    }

                    context.SaveChanges(); // Guardar cambios en la base de datos
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

        public static Result CompletarCitasByUsuario(int idCita)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var citas = context.Citas.Where(cita => cita.IdCita == idCita); // Obtener citas no canceladas del usuario

                    foreach (var cita in citas)
                    {
                        cita.Estatus = 5; // Cambiar el estatus a "Rechazada"
                    }

                    context.SaveChanges(); // Guardar cambios en la base de datos
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

        public static Result LLamada(int idCita, string url)
        {
            Result result = new Result();

            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    // Actualiza la URL en la base de datos
                    var cita = context.Citas.FirstOrDefault(c => c.IdCita == idCita);
                    if (cita != null)
                    {
                        cita.Link = url;
                        context.SaveChanges();
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

        public static Result GetCitaById(int idCita)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var query = from cita in context.Citas
                                join especialista in context.Especialistas on cita.IdEspecialista equals especialista.IdEspecialista
                                join paciente in context.Pacientes on cita.IdUsuario equals paciente.IdUsuario
                                where cita.IdCita == idCita
                                select new
                                {
                                    CitaId = cita.IdCita,
                                    UsuarioId = cita.IdUsuario,
                                    EspecialistaId = cita.IdEspecialista,
                                    cita.Fecha,
                                    cita.Horario,
                                    cita.Estatus,
                                    cita.Virtual,
                                    cita.Link,
                                    cita.Observacion,
                                    NombreEspecialista = especialista.Usuario.Nombre,
                                    ApellidoPaternoEspecialista = especialista.Usuario.ApellidoPaterno,
                                    ApellidoMaternoEspecialista = especialista.Usuario.ApellidoMaterno,
                                    NombrePaciente = paciente.Nombre,
                                    ApellidoPaternoPaciente = paciente.ApellidoPaterno,
                                    ApellidoMaternoPaciente = paciente.ApellidoMaterno
                                };


                    var item = query.FirstOrDefault();

                    if (item != null)
                    {
                        ML.Cita cita = new ML.Cita();
                        cita.IdCita = item.CitaId;
                        cita.Usuario = new ML.Usuario();
                        cita.Usuario.IdUsuario = item.UsuarioId.Value;
                        cita.Especialista = new ML.Especialista();
                        cita.Especialista.IdEspecialista = item.EspecialistaId.Value;
                        cita.Especialista.Usuario = new ML.Usuario();
                        cita.Especialista.Usuario.Nombre = item.NombreEspecialista;
                        cita.Especialista.Usuario.ApellidoPaterno = item.ApellidoPaternoEspecialista;
                        cita.Especialista.Usuario.ApellidoMaterno = item.ApellidoMaternoEspecialista;
                        cita.Usuario.Paciente = new ML.Paciente();
                        cita.Usuario.Paciente.Nombre = item.NombrePaciente;
                        cita.Usuario.Paciente.ApellidoPaterno = item.ApellidoPaternoPaciente;
                        cita.Usuario.Paciente.ApellidoMaterno = item.ApellidoMaternoPaciente;
                        cita.Virtual = item.Virtual.Value;
                        cita.Observacion = item.Observacion;
                        cita.Link = item.Link;
                        cita.Fecha = item.Fecha.Value.Date;
                        cita.Horario = item.Horario.Value;
                        cita.Estatus = item.Estatus.Value;


                        result.Object = cita;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró la cita con el ID especificado.";
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

        public static Result AddDetalles(int idcita, string observaciones)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities1 context = new DL.EnlazaTEA2023Entities1())
                {
                    var cita = context.Citas.FirstOrDefault(c => c.IdCita == idcita);
                    if (cita != null)
                    {
                        cita.Observacion = observaciones;
                        int rowsAffected = context.SaveChanges();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo actualizar la observación de la cita.";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró la cita con el ID especificado.";
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
