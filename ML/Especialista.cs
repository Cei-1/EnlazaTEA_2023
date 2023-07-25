using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Especialista
    {
        public int IdEspecialista { get; set; }
        public string NombreCarrera { get; set; }
        public string NoCedula { get; set; }
        public string Especialidad { get; set; }
        public string Calle { get; set; }
        public string NumeroExterno { get; set; }
        public string NumeroInterno { get; set; }
        public string Colonia { get; set; } // Nuevo campo Colonia
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; } // Nuevo campo Celular
        public bool Estatus { get; set; }
        public ML.Usuario Usuario { get; set; }
        public List<object> Especialistas { get; set; }
    }
}
