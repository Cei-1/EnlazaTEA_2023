using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo 'Nombre' es requerido.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo 'Apellido Paterno' es requerido.")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo 'Apellido Materno' es requerido.")]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El campo 'Fecha de Nacimiento' es requerido.")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Fotografía")]
        public byte[] Fotografia { get; set; }

        [Required(ErrorMessage = "El campo 'Email' es requerido.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "El campo 'Email' debe ser una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo 'Contraseña' es requerido.")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        public Rol Rol { get; set; }
        public List<object> Usuarios { get; set; }
        public Paciente Paciente { get; set; }

    }
}
