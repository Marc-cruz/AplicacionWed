using PumasUnah.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PumasUnah.WedAdmin.Controllers
{
    public class EntradaController : Controller
    {

        EntradaBL _entradaBL;

        public EntradaController()
        {
            _entradaBL = new EntradaBL();
        }

    
        // GET: Entrada
        public ActionResult Index()
        {

            var ListadeEntrada = _entradaBL.ObtenerEntradas();

            return View(ListadeEntrada);
        }

        public ActionResult Crear()
        {
            var nuevaEntrada = new Entrada();

            return View(nuevaEntrada);
        }

        [HttpPost]
        public ActionResult Crear (Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                if(entrada.Descripcion != entrada.Descripcion.Trim())
                {
                    ModelState.AddModelError("descripcion", "la descipcion no debe de contener espacio al incio o al final");
                    return View(entrada);
                }
                _entradaBL.GuardarEntrada(entrada);

                return RedirectToAction("Index");
            }
            return View(entrada);
        }

        public ActionResult Editar(int Id)
        {
            var entrada =_entradaBL.ObtenerEntrada(Id);

            return View(entrada);
        }

        [HttpPost]
        public ActionResult Editar (Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                if (entrada.Descripcion != entrada.Descripcion.Trim())
                {
                    ModelState.AddModelError("descripcion", "la descipcion no debe de contener espacio al incio o al final");
                    return View(entrada);
                }
                _entradaBL.GuardarEntrada(entrada);

                return RedirectToAction("Index");
            }
            return View(entrada);
        }

        public ActionResult Detalle(int Id)
        {
            var entrada = _entradaBL.ObtenerEntrada(Id);

            return View(entrada);
        } 

        public ActionResult Eliminar (int Id)
        {
            var entrada = _entradaBL.ObtenerEntrada(Id);

            return View(entrada);
        }

        [HttpPost]
        public ActionResult Eliminar(Entrada entrada)
        {
            _entradaBL.EliminarEntrada(entrada.Id);

            return RedirectToAction("Index");
        }
    }
}