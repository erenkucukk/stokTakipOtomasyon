using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class KategoriController : Controller
    {
        StokTakipContext db = new StokTakipContext();

        // GET: Kategori
        public ActionResult Index()
        {
            List<Kategori> kategoriler = db.Kategoris.Where(x => x.KategoriDurum == true).ToList();
            return View(kategoriler);
        }
    }
}