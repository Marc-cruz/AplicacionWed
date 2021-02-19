
using PumasUnah.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PumasUNAH.Wed.Controllers
{
    public class EntradaController : Controller
    {
        // GET: Entradas
        public ActionResult Index()
        {
            var entradasBL = new EntradaBL();
            var listadeEntradas = entradasBL.ObtenerEntradas();

            return View(listadeEntradas);
        }
    }
}