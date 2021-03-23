using System;
using System.Collections.Generic;
using System.Linq;


namespace PumasUnah.BL
{
    public class EntradaBL
    {
        Contexto _contexto;
        public List<Entrada> listadeEntrada { get; set; }

        public EntradaBL()
        {
            _contexto = new Contexto();
            listadeEntrada = new List<Entrada>();
        }

        public List<Entrada> ObtenerEntradas()
        {
            listadeEntrada = _contexto.Entrada.ToList();
            return listadeEntrada;
        }

        public void GuardarEntrada(Entrada entrada)
        {
            if(entrada.Id == 0)
            {
                _contexto.Entrada.Add(entrada);
            }
            else
            {
                var entradaExistente = _contexto.Entrada.Find(entrada.Id);
                entradaExistente.Descripcion = entrada.Descripcion;
                entradaExistente.Precio = entrada.Precio;
            }
            
            _contexto.SaveChanges();
        }

        public Entrada ObtenerEntrada(int Id)
        {
            var entrada = _contexto.Entrada.Find(Id);
            return entrada;
        }

        public void EliminarEntrada(int Id)
        {
            var entrada = _contexto.Entrada.Find(Id);

            _contexto.Entrada.Remove(entrada);
            _contexto.SaveChanges();
        }

    }
}
