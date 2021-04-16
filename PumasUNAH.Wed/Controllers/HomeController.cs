﻿using PumasUnah.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PumasUNAH.Wed.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var TiendaBL = new TiendaBL();
            var listadeTienda = TiendaBL.ObtenerTienda();
            ViewBag.adminwebsiteurl = ConfigurationManager.AppSettings["adminwebsiteurl"];

            return View(listadeTienda);
        }
    }
}