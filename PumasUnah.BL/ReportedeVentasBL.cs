using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumasUnah.BL
{
    public class ReportedeVentasBL
    {
        Contexto _contexto;
        public List<ReportedeVentas> ListadeVentas { get; set; }

        public ReportedeVentasBL()
        {
        _contexto = new Contexto();
            ListadeVentas = new List<ReportedeVentas>();
      }

        public List<ReportedeVentas> ObtenerVentas()
        {
            ListadeVentas = _contexto.OrdenDetalle
                .Include("Tienda")
                .Where(r => r.Orden.Activo)
                .GroupBy(r => r.Tienda.Descripcion)
                .Select(r => new ReportedeVentas()
                {
                    Tienda = r.Key,
                    Cantidad = r.Sum(s => s.Cantidad),
                    Total = r.Sum(s => s.Total)
                }).ToList();

            return ListadeVentas;
        }
    }
}
