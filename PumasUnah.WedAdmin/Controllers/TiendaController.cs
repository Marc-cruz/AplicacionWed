using PumasUnah.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PumasUnah.WedAdmin.Controllers
{
    [Authorize]
    public class TiendaController : Controller
    {
        TiendaBL _tiendaBL;
        CategoriaBL _categoriaBL;

        public TiendaController()
        {
            _tiendaBL = new TiendaBL();
            _categoriaBL = new CategoriaBL();
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
            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");
            return View(nuevaTienda);
        }

        [HttpPost]
        public ActionResult Crear(Tienda tienda, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (tienda.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "seleccione una categoria");
                    return View(tienda);
                }

                if (imagen != null)
                {
                    tienda.UrlImagen = GuardarImagen(imagen);
                }

                _tiendaBL.GuardarTienda(tienda);

                return RedirectToAction("Index");
            }

            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(tienda);
        }

        public ActionResult Editar(int Id)
        {
            var tienda = _tiendaBL.ObtenerTienda(Id);
            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", tienda.CategoriaId);
            return View(tienda);
        }

        [HttpPost]
        public ActionResult Editar(Tienda tienda, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (tienda.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "seleccione una categoria");
                    return View(tienda);
                }

                if (imagen != null)
                {
                    tienda.UrlImagen = GuardarImagen(imagen);
                }

                _tiendaBL.GuardarTienda(tienda);

                return RedirectToAction("Index");
            }

            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

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