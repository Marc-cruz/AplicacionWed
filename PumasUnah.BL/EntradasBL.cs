using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumasUnah.BL
{
    public class EntradasBL
    {
        public List<Entradas> ObtenerEntradas()
        {
            var entrada1 = new Entradas();
            entrada1.Id = 1;
            entrada1.Descripcion = "VIP";
            entrada1.Precio = 1500;

            var entrada2 = new Entradas();
            entrada2.Id = 2;
            entrada2.Descripcion = "Palco";
            entrada2.Precio = 1000;

            var entrada3 = new Entradas();
            entrada3.Id = 3;
            entrada3.Descripcion = "Silla";
            entrada3.Precio = 500;

            var entrada4 = new Entradas();
            entrada4.Id = 4;
            entrada4.Descripcion = "Sol";
            entrada4.Precio = 100;

            var ListadeEntradas = new List<Entradas>();
            ListadeEntradas.Add(entrada1);
            ListadeEntradas.Add(entrada2);
            ListadeEntradas.Add(entrada3);
            ListadeEntradas.Add(entrada4);

            return ListadeEntradas;
        }

    }
}
