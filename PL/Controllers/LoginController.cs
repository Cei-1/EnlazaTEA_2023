﻿using ML;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Register() 
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultRol = BL.Rol.GetAll();
            usuario.Rol = new Rol();
            usuario.Rol.Roles = resultRol.Objects;
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Register(ML.Usuario usuario)
        {

            ML.Result validarEmail = BL.Usuario.Validar(usuario.Email);
            if (validarEmail.Correct)
            {
                ViewBag.Mensaje1 = "Este email ya esta registrado intente con otro";
                ML.Result resultRol = BL.Rol.GetAll();
                usuario.Rol = new Rol();
                usuario.Rol.Roles = resultRol.Objects;
                return View("Register", usuario);
            }
            else
            {
                string hashedPassword = GenerateHash(usuario.Contraseña);

                usuario.Contraseña = hashedPassword;



                ML.Result result = BL.Usuario.Add(usuario);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Usuario asignado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha podido agregar el usuario. Error: " + result.ErrorMessage;
                }
                return PartialView("Modal");
            } 
        }

        public string GenerateHash(string contraseña)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                string key = "x2";
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString(key));
                    }

                    return builder.ToString();
                }
            }

        public ActionResult CompletarEspecialista()
        {
            return View();
        }

        public ActionResult Validacion(string email, string Contraseña)
        {
            string hashedPassword = GenerateHash(Contraseña);

            string pass = hashedPassword;
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            ML.Result result = BL.Usuario.Validar(email);


            if (result.Correct)
            {
                usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                usuario.Email = ((ML.Usuario)result.Object).Email;
                usuario.Contraseña = ((ML.Usuario)result.Object).Contraseña;

                if (usuario.Contraseña == pass)
                {
                    usuario.Rol = new ML.Rol();
                    usuario.Rol.IdRol = ((ML.Usuario)result.Object).Rol.IdRol;
                    Session["SessionRol"] = usuario.Rol.IdRol;
                    Session["SessionUsuario"] = usuario.IdUsuario;
                    if(usuario.Rol.IdRol == 1)
                    {
                        return RedirectToAction("CompletarEspecialista");
                    }else if (usuario.Rol.IdRol == 2)
                    {
                        return RedirectToAction("RegistrarPaciente");
                    }    
                }
                else
                {
                    ViewBag.Mensaje2 = "Contraseña incorrecta";
                }
            }
            else
            {
                ViewBag.Mensaje1 = "Email no registrado";
            }
            usuario.Contraseña = Contraseña;
            return View("Form", usuario);
        }

        [HttpGet]
        public ActionResult CompletarEspecialista(ML.Especialista especialista)
        {
            // Obtener el valor de SessionUsuario
            int idUsuario = Convert.ToInt32(Session["SessionUsuario"]);

            // Llamar al método GetByIdEF para obtener el especialista asociado al usuario
            ML.Result result = BL.Especialista.GetByIdEF(idUsuario);

            if (result.Correct && result.Object != null)
            {
                // Si se encontró un especialista asociado al usuario, redirige al Index
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Si no se encontró un especialista asociado al usuario, muestra la vista
                return View();
            }
        }

        [HttpPost]
        public ActionResult CompletarEspecialistaP(ML.Especialista especialista)
        {
            int idUsuario = Convert.ToInt32(Session["SessionUsuario"]);
            especialista.Usuario = new ML.Usuario { IdUsuario = idUsuario };
            especialista.Estatus = false;

            ML.Result result = BL.Especialista.Add(especialista);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Usuario completado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido completar el usuario. Error: " + result.ErrorMessage;
            }

            return PartialView("Modal2");
        }

        [HttpGet]
        public ActionResult RegistrarPaciente(ML.Paciente paciente)
        {
            // Obtener el valor de SessionUsuario
            int idUsuario = Convert.ToInt32(Session["SessionUsuario"]);

            // Llamar al método GetByIdEF para obtener el especialista asociado al usuario
            ML.Result result = BL.Paciente.GetByIdEF(idUsuario);

            if (result.Correct && result.Object != null)
            {
                // Si se encontró un especialista asociado al usuario, redirige al Index
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Si no se encontró un especialista asociado al usuario, muestra la vista
                return View();
            }
        }

        [HttpPost]
        public ActionResult AgregarPaciente(ML.Paciente paciente)
        {
            int idUsuario = Convert.ToInt32(Session["SessionUsuario"]);
            paciente.Usuario = new ML.Usuario { IdUsuario = idUsuario };
            paciente.NivelTDA = 1;

            ML.Result result = BL.Paciente.Add(paciente);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Paciente agregado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido agregar el paciente. Error: " + result.ErrorMessage;
            }

            return PartialView("Modal2");
        }
    }

}
