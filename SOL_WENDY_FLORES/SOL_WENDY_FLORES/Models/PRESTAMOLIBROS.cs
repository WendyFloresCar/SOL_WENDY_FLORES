using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SOL_WENDY_FLORES.Models
{
    public class PRESTAMOLIBROS
    {
        public int ID { get; set; }
        public int IDLIBROS { get; set; }
        public int IDUSUARIOS { get; set; }
        public string TIPOLECTURA { get; set; }
        public DateTime FECHAPRESTAMO { get; set; }
        public DateTime? FECHADEVOLUCION { get; set; }
        [ForeignKey("IDUSUARIOS")]
        public USUARIOS USUARIOS { get; set; }
        [ForeignKey("IDLIBROS")]
        public LIBROS LIBROS { get; set; }
    }
}