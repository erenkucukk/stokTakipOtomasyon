using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class SiparisController : Controller
    {
        StokTakipContext db = new StokTakipContext();

        // GET: Siparis
        public ActionResult Index()
        {
            List<Siparis> siparisler = db.Sipariss.ToList();
            return View(siparisler);
        }
    }
}