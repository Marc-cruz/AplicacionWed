using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumasUnah.BL
{
    public class Tienda
    {
        public int Id { get; set; }
        [Display(Name = "descripcion")]
        [Required(ErrorMessage="inrgese la descripcion")]
        [MinLength(3, ErrorMessage ="ingrese minimo tres caracteres")]
        [MaxLength(20, ErrorMessage="ingrese maximo 20 caracteres") ]
        public string Descripcion { get; set; }
        [Required(ErrorMessage ="ingrese el precio")]
        [Range(0, 1000, ErrorMessage ="ingrese un precio entre 0 y 1000")]
        [Display(Name ="imagen")]
        public string UrlImagen { get; set; }
            }
}
