using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumasUnah.BL
{
    public class Entrada
    {

        public Entrada()
        {
            Activo = true;
        }

        public int Id { get; set; }
        [Required(ErrorMessage ="ingrese la categoria")]
        public string Descripcion { get; set; }
        public double  Precio { get; set; }
        public Tienda Tienda { get; set; }
        public bool Activo { get; set; }
    } 
}
