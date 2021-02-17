using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumasUnah.BL
{
    public class TiendaBL
    {
        Contexto _contexto;
        public List<Tienda> ListadeTienda { get; set; }

        public TiendaBL()
        {
            _contexto = new Contexto();
            ListadeTienda = new List<Tienda>();
        }
       public List<Tienda> ObtenerTienda()
        {

            ListadeTienda = _contexto.Tienda.ToList();

            return ListadeTienda;
        }

    }
}
