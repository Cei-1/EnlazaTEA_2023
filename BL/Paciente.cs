using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static Result Add(ML.Paciente paciente)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.AgregarPaciente(paciente.Nombre,paciente.ApellidoPaterno, paciente.ApellidoMaterno, paciente.Parentesco, paciente.NivelTEA, paciente.Sexo, paciente.Edad, paciente.Calle, paciente.NumeroExterior,paciente.NumeroInterior,paciente.Colonia,paciente.Municipio,paciente.Estado,paciente.CP,paciente.Escolaridad,paciente.Usuario.IdUsuario);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "The register was not inserted";
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
                    // Obtener los datos del paciente mediante el procedimiento almacenado
                    var pacienteDL = context.BuscarPacientePorIdUsuario(IdUsuario).SingleOrDefault();
                    if (pacienteDL != null)
                    {
                        ML.Paciente paciente = new ML.Paciente();
                        paciente.IdPaciente = pacienteDL.IdPaciente;
                        paciente.Nombre = pacienteDL.Nombre;
                        paciente.ApellidoPaterno = pacienteDL.ApellidoPaterno;
                        paciente.ApellidoMaterno = pacienteDL.ApellidoMaterno;
                        paciente.Parentesco = pacienteDL.Parentesco;
                        paciente.NivelTEA = pacienteDL.NivelTDA.Value;
                        paciente.Sexo = pacienteDL.Sexo.Value;
                        paciente.Edad = pacienteDL.Edad.Value;
                        paciente.Calle = pacienteDL.Calle;
                        paciente.NumeroExterior = pacienteDL.NumeroExterior;
                        paciente.NumeroInterior = pacienteDL.NumeroInterior;
                        paciente.Colonia = pacienteDL.Colonia; // Nuevo campo Colonia
                        paciente.Municipio = pacienteDL.Municipio;
                        paciente.Estado = pacienteDL.Estado;
                        paciente.CP = pacienteDL.CP;
                        paciente.Escolaridad = pacienteDL.Escolaridad;
                        paciente.Usuario = new ML.Usuario();
                        paciente.Usuario.IdUsuario = pacienteDL.IdUsuario.Value;
                        result.Object = paciente;
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    // Obtener todos los registros de la tabla Paciente
                    var pacientesDL = context.Pacientes.ToList();

                    if (pacientesDL != null && pacientesDL.Count > 0)
                    {
                        List<ML.Paciente> pacientes = new List<ML.Paciente>();

                        foreach (var pacienteDL in pacientesDL)
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.IdPaciente = pacienteDL.IdPaciente;
                            paciente.Nombre = pacienteDL.Nombre;
                            paciente.ApellidoPaterno = pacienteDL.ApellidoPaterno;
                            paciente.ApellidoMaterno = pacienteDL.ApellidoMaterno;
                            paciente.Parentesco = pacienteDL.Parentesco;
                            paciente.NivelTEA = pacienteDL.NivelTDA.Value;
                            paciente.Sexo = pacienteDL.Sexo.Value;
                            paciente.Edad = pacienteDL.Edad.Value;
                            paciente.Calle = pacienteDL.Calle;
                            paciente.NumeroExterior = pacienteDL.NumeroExterior;
                            paciente.NumeroInterior = pacienteDL.NumeroInterior;
                            paciente.Colonia = pacienteDL.Colonia;
                            paciente.Municipio = pacienteDL.Municipio;
                            paciente.Estado = pacienteDL.Estado;
                            paciente.CP = pacienteDL.CP;
                            paciente.Escolaridad = pacienteDL.Escolaridad;
                            paciente.Usuario = new ML.Usuario();
                            paciente.Usuario.IdUsuario = pacienteDL.IdUsuario.Value;

                            pacientes.Add(paciente);
                        }

                        result.Objects = result.Objects = pacientes.Cast<object>().ToList();
                        ;
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

        public static ML.Result AddEvaluacion(int Id, int nuevaEvaluacion)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    // Buscar el paciente por su ID
                    var paciente = context.Pacientes.SingleOrDefault(p => p.IdUsuario == Id);

                    if (paciente != null)
                    {
                        // Actualizar el campo Evaluacion
                        paciente.Evaluacion = nuevaEvaluacion;
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

        public static ML.Result UpdateNivel(int Id, int nuevaEvaluacion)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    // Buscar el paciente por su ID
                    var paciente = context.Pacientes.SingleOrDefault(p => p.IdUsuario == Id);

                    if (paciente != null)
                    {
                        // Actualizar el campo Evaluacion
                        paciente.NivelTDA = nuevaEvaluacion;
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
