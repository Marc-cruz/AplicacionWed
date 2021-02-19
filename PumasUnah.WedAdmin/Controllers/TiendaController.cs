using PumasUnah.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PumasUnah.WedAdmin.Controllers
{
    public class TiendaController : Controller
    {
        TiendaBL _tiendaBL;

        public TiendaController()
        {
            _tiendaBL = new TiendaBL();
        }

        // GET: Tienda
        public ActionResult Index()
        {

            var listadeTienda = _tiendaBL.ObtenerTienda();

            return View(listadeTienda);
        }

        public ActionResult Crear()
        {
            var nuevaTienda = new Tienda();
            return View(nuevaTienda);
        }

        [HttpPost]
        public ActionResult Crear(Tienda entrada)
        {
            _tiendaBL.GuardarTienda(entrada);

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int Id)
        {
            var entrada = _tiendaBL.ObtenerTienda(Id);

            return View(entrada);
        }

        [HttpPost]
        public ActionResult Editar(Tienda entrada)
        {
            _tiendaBL.GuardarTienda(entrada);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle (int Id)
        {
            var entrada = _tiendaBL.ObtenerTienda(Id);

            return View(entrada);
        }

        public ActionResult Eliminar (int Id)
        {
            var entrada = _tiendaBL.ObtenerTienda(Id);

            return View(entrada);
        }

        [HttpPost]
        public ActionResult Eliminar(Tienda entrada)
        {
            _tiendaBL.EliminarTienda(entrada.Id);

            return RedirectToAction("Index");
        }
    }
}