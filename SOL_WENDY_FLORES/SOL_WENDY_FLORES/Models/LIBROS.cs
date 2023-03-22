using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOL_WENDY_FLORES.Models
{
    public class LIBROS
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string CATEGORIA { get; set; }
        public string AUTOR { get; set; }
        public string PAIS { get; set; }
        public DateTime FECHAPUBLICACION { get; set; }
        public string EDITORIAL { get; set; }
    }
}