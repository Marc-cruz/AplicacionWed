
using PumasUnah.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PumasUNAH.Wed.Controllers
{
    public class EntradasController : Controller
    {
        // GET: Entradas
        public ActionResult Index()
        {
            var entradasBL = new EntradasBL();
            var ListadeEntradas = entradasBL.ObtenerEntradas();

            return View(ListadeEntradas);
        }
    }
}