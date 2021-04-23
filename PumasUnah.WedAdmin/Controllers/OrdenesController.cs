using PumasUnah.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PumasUnah.WedAdmin.Controllers
{
    [Authorize]
    public class OrdenesController : Controller
    {
        OrdenesBL _ordenesBL;
        ClienteBL _clienteBL;
 

        public OrdenesController()
        {
            _ordenesBL = new OrdenesBL();
            _clienteBL = new ClienteBL();
          
        }


        // GET: Ordenes
        public ActionResult Index()
        {
            var ListadeOrdenes = _ordenesBL.ObtenerOrdenes();

            return View(ListadeOrdenes);
        }

        public ActionResult Crear()
        {
            var nuevaOrden = new Orden();
            var cliente = _clienteBL.ObtenerClientesActivos();

            ViewBag.ClienteId = new SelectList(cliente, "Id", "Nombre");

            return View(nuevaOrden);
        }

        [HttpPost]
        public ActionResult Crear(Orden orden)
        {
            if (ModelState.IsValid)
            {
                if (orden.ClienteId == 0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un cliente");
                    return View(orden);
                }

                _ordenesBL.GuardarOrden(orden);
                return RedirectToAction("Index");
            }

            var cliente = _clienteBL.ObtenerClientesActivos();

            ViewBag.ClienteId = new SelectList(cliente, "Id", "Nombre");

            return View(orden);
        }

        public ActionResult Editar(int id)
        {
            var orden = new Orden();
            var cliente = _clienteBL.ObtenerClientesActivos();

            ViewBag.ClienteId = new SelectList(cliente, "Id", "Nombre", orden.ClienteId);

            return View(orden);
        }

        [HttpPost]
        public ActionResult Editar(Orden orden)
        {
            if (ModelState.IsValid)
            {
                if (orden.ClienteId == 0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un cliente");
                    return View(orden);
                }

                _ordenesBL.GuardarOrden(orden);
                return RedirectToAction("Index");
            }

            var cliente = _clienteBL.ObtenerClientesActivos();

            ViewBag.ClienteId = new SelectList(cliente, "Id", "Nombre", orden.ClienteId);

            return View(orden);
        }

        public ActionResult Detalle(int id)
        {
            var orden = _ordenesBL.ObtenerOrden(id);
            return View(orden);
        }
    }
}