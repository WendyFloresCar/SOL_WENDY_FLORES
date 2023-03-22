using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOL_WENDY_FLORES.Models
{
    public class PRESTAMOVIEWMODEL
    {
        public decimal IdPrestamo { get; set; }
        public decimal IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public string DniUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string TipoLectura { get; set; }
        public DateTime? FechaDevolucion { get; set; }

    }
}