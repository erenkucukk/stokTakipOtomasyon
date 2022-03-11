using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class AltKategoriController : Controller
    {
        StokTakipContext db = new StokTakipContext();

        // GET: AltKategori
        public ActionResult Index()
        {
            return View();
        }
    }
}