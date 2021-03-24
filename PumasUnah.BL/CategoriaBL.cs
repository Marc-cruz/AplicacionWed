using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumasUnah.BL
{
    public class CategoriaBL
    {
        Contexto _contexto;
        public List<Categoria> ListadeCategoria { get; set; }

        public CategoriaBL()
        {
            _contexto = new Contexto();
            ListadeCategoria = new List<Categoria>();
        }
        public List<Categoria> ObtenerCategorias()
        {
            ListadeCategoria = _contexto.Categoria.ToList();
            return ListadeCategoria;
        }

        public void GuardarCategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                _contexto.Categoria.Add(categoria);
            }
            else
            {
                var categoriaExistente = _contexto.Categoria.Find(categoria.Id);
                categoriaExistente.Descripcion = categoria.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public Categoria ObtenerCategoria(int id)
        {
            var categoria = _contexto.Categoria.Find(id);

            return categoria;
        }

        public void EliminarCategoria(int id)
        {
            var categoria = _contexto.Categoria.Find(id);

            _contexto.Categoria.Remove(categoria);
            _contexto.SaveChanges();
        }
    }
}
