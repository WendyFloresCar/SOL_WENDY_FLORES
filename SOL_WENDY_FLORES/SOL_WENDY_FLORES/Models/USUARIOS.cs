using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SOL_WENDY_FLORES.Models
{
    public class USUARIOS
    {
        public int ID { get; set; }
        public string NUMERODNI { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONO { get; set; }
        public string ESTADO { get; set; }
        public string TIPOUSUARIO { get; set; }
        [NotMapped]
        public string NombreCompleto
        {
            get { return NOMBRES + " " + APELLIDOS; }
        }
    }
}