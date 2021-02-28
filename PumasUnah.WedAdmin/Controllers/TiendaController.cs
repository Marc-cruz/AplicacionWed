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
        public ActionResult Crear(Tienda tienda, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (tienda.Id == 0)
                {
                    ModelState.AddModelError("descripcion", "seleccione una categoria");
                    return View(tienda);
                }
                if (imagen != null)
                {
                    tienda.UrlImagen = GuardarImagen(imagen);
                }

                _tiendaBL.GuardarTienda(tienda);

                return RedirectToAction("Index");
            }
            var nuevaTienda = new Tienda();
            
            return View(tienda);
        }

        public ActionResult Editar(int Id)
        {
            var entrada = _tiendaBL.ObtenerTienda(Id);

            return View(entrada);
        }

        [HttpPost]
        public ActionResult Editar(Tienda tienda)
        {
            if (ModelState.IsValid)
            {
                if (tienda.Id == 0)
                {
                    ModelState.AddModelError("descripcion", "seleccione una categoria");
                    return View(tienda);
                }

                _tiendaBL.GuardarTienda(tienda);

                return RedirectToAction("Index");
            }
            var nuevaTienda = new Tienda();

            return View(tienda);
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
        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}