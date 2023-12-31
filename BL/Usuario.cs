﻿using ML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static Result Add(ML.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    //DateTime dt = DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var query = context.AddUsuario(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,usuario.FechaNacimiento,usuario.Email,usuario.Contraseña,usuario.Rol.IdRol);

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

        public static ML.Result Validar(string email)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.GetUsuarioByEmail(email).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Email = query.Email;
                        usuario.Contraseña = query.Contraseña;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;
                        result.Object = usuario;
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

        public static ML.Result UpdateImagen(int idUsuario, string fileName)
        {
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2()) // Reemplaza "YourDbContext" con el nombre real de tu contexto
                {
                    // Obtener el usuario por su Id
                    var usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                    if (usuario != null)
                    {
                        // Actualizar la propiedad de la imagen con el nuevo nombre de archivo
                        usuario.Fotografia = fileName;

                        // Guardar los cambios en la base de datos
                        context.SaveChanges();

                        return new ML.Result { Correct = true };
                    }
                    else
                    {
                        return new ML.Result { Correct = false, ErrorMessage = "Usuario no encontrado." };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ML.Result { Correct = false, ErrorMessage = "Error al actualizar la imagen: " + ex.Message };
            }
        }

        public static ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var usuarioQuery = context.GetUserById(idUsuario).SingleOrDefault();

                    if (usuarioQuery != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = usuarioQuery.IdUsuario;
                        usuario.Nombre = usuarioQuery.Nombre;
                        usuario.ApellidoPaterno = usuarioQuery.ApellidoPaterno;
                        usuario.ApellidoMaterno = usuarioQuery.ApellidoMaterno;
                        usuario.FechaNacimiento = usuarioQuery.FechaNacimiento.Value;
                        usuario.Email = usuarioQuery.Email;
                        usuario.Contraseña = usuarioQuery.Contraseña;
                        usuario.Paciente= new ML.Paciente();
                        usuario.Paciente.IdPaciente = usuarioQuery.IdPaciente.Value;
                        usuario.Paciente.Nombre = usuarioQuery.NombreP;
                        usuario.Paciente.ApellidoPaterno = usuarioQuery.ApellidoPP;
                        usuario.Paciente.ApellidoMaterno = usuarioQuery.ApellidoMP;
                        usuario.Paciente.Parentesco = usuarioQuery.Parentesco;
                        usuario.Paciente.NivelTEA = usuarioQuery.NivelTDA.Value;
                        usuario.Paciente.Sexo = usuarioQuery.Sexo.Value;
                        usuario.Paciente.Edad = usuarioQuery.Edad.Value;
                        usuario.Paciente.Calle = usuarioQuery.Calle;
                        usuario.Paciente.NumeroExterior = usuarioQuery.NumeroExterior;
                        usuario.Paciente.NumeroInterior = usuarioQuery.NumeroInterior;
                        usuario.Paciente.Colonia = usuarioQuery.Colonia;
                        usuario.Paciente.Municipio = usuarioQuery.Municipio;
                        usuario.Paciente.Estado = usuarioQuery.Estado;
                        usuario.Paciente.CP = usuarioQuery.CP;
                        usuario.Paciente.Escolaridad = usuarioQuery.Escolaridad;
                        usuario.Paciente.Evaluacion = usuarioQuery.Evaluacion.Value;

                        result.Object = usuario;
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

        public static Result UpdateUser(ML.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var query = context.UpdateUser(
                        usuario.IdUsuario,
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,
                        usuario.FechaNacimiento,
                        usuario.Email,
                        usuario.Contraseña
                    );

                    if (query >= -1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "The user was not updated";
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

        public static ML.Result GetPacienteByIdUsuario(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var pacienteQuery = context.GetPacienteByIdUsuario(idUsuario).SingleOrDefault();

                    if (pacienteQuery != null)
                    {
                        ML.Paciente paciente = new ML.Paciente();
                        paciente.IdPaciente = pacienteQuery.IdPaciente;
                        paciente.Nombre = pacienteQuery.Nombre;
                        paciente.ApellidoPaterno = pacienteQuery.ApellidoPaterno;
                        paciente.ApellidoMaterno = pacienteQuery.ApellidoMaterno;
                        paciente.Parentesco = pacienteQuery.Parentesco;
                        paciente.NivelTEA = pacienteQuery.NivelTDA.Value;
                        paciente.Sexo = pacienteQuery.Sexo.Value;
                        paciente.Edad = pacienteQuery.Edad.Value;
                        paciente.Calle = pacienteQuery.Calle;
                        paciente.NumeroExterior = pacienteQuery.NumeroExterior;
                        paciente.NumeroInterior = pacienteQuery.NumeroInterior;
                        paciente.Colonia = pacienteQuery.Colonia;
                        paciente.Municipio = pacienteQuery.Municipio;
                        paciente.Estado = pacienteQuery.Estado;
                        paciente.CP = pacienteQuery.CP;
                        paciente.Escolaridad = pacienteQuery.Escolaridad;

                        result.Object = paciente;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros de paciente.";
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

        public static ML.Result UpdatePaciente(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EnlazaTEA2023Entities2 context = new DL.EnlazaTEA2023Entities2())
                {
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@IdPaciente", paciente.IdPaciente),
                        new SqlParameter("@Nombre", paciente.Nombre),
                        new SqlParameter("@ApellidoPaterno", paciente.ApellidoPaterno),
                        new SqlParameter("@ApellidoMaterno", paciente.ApellidoMaterno),
                        new SqlParameter("@Parentesco", paciente.Parentesco),
                        new SqlParameter("@NivelTDA", paciente.NivelTEA),
                        new SqlParameter("@Sexo", paciente.Sexo),
                        new SqlParameter("@Edad", paciente.Edad),
                        new SqlParameter("@Calle", paciente.Calle),
                        new SqlParameter("@NumeroExterior", paciente.NumeroExterior),
                        new SqlParameter("@NumeroInterior", paciente.NumeroInterior),
                        new SqlParameter("@Colonia", paciente.Colonia),
                        new SqlParameter("@Municipio", paciente.Municipio),
                        new SqlParameter("@Estado", paciente.Estado),
                        new SqlParameter("@CP", paciente.CP),
                        new SqlParameter("@Escolaridad", paciente.Escolaridad)
                    };

                    int rowsAffected = context.Database.ExecuteSqlCommand("EXEC UpdatePaciente @IdPaciente, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Parentesco, @NivelTDA, @Sexo, @Edad, @Calle, @NumeroExterior, @NumeroInterior, @Colonia, @Municipio, @Estado, @CP, @Escolaridad", parameters);

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el registro de paciente para actualizar.";
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
