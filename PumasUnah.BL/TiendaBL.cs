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
        public List<Tienda> listadeTienda{ get; set; }

        public TiendaBL()
        {
            _contexto = new Contexto();
            listadeTienda = new List<Tienda>();
        }

        public List<Tienda> ObtenerTienda()
        {
            listadeTienda = _contexto.Tienda
                .Include("Categoria")
                .OrderBy(r => r.Categoria.Descripcion)
                .ThenBy(r => r.Descripcion)
                .ToList();

            return listadeTienda;
        }

        public List<Tienda> ObtenerTiendaActivos()
        {
            listadeTienda = _contexto.Tienda
                .Include("Categoria")
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Descripcion)
                .ToList();

            return listadeTienda;
        }

        public void GuardarTienda(Tienda tienda)
        {
            if (tienda.Id == 0)
            {
                _contexto.Tienda.Add(tienda);
            }
            else
            {
                var tiendaExistente = _contexto.Tienda.Find(tienda.Id);
                tiendaExistente.Descripcion = tienda.Descripcion;
                tiendaExistente.CategoriaId = tienda.CategoriaId;
                tiendaExistente.Precio = tienda.Precio;
                tiendaExistente.UrlImagen = tienda.UrlImagen;
            }

            _contexto.SaveChanges();
        }

        public Tienda ObtenerTienda(int id)
        {
            var tienda = _contexto.Tienda
                .Include("Categoria").FirstOrDefault(p => p.Id == id);
            return tienda;
        }

        public void EliminarTienda(int Id)
        {
            var tienda = _contexto.Tienda.Find(Id);

            _contexto.Tienda.Remove(tienda);
            _contexto.SaveChanges();
        }

    }
}
