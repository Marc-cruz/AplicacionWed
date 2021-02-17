
using PumasUnah.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PumasUNAH.Wed.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda
        public ActionResult Index()
        {
            var tiendaBL = new TiendaBL();
            var ListadeTienda = tiendaBL.ObtenerTienda();
            
          
            return View(ListadeTienda);
        }
    }
}