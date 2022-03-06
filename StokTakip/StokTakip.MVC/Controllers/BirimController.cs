using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class BirimController : Controller
    {
        StokTakipContext db = new StokTakipContext();
        // GET: Birim
        public ActionResult Index()
        {
            List<Birim> birimler = db.Birims.Where(x => x.BirimDurum == true).ToList();
            return View(birimler);
        }
    }
}