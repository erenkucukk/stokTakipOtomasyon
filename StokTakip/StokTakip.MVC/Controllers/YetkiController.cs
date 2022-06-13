using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class YetkiController : Controller
    {
        StokTakipContext db = new StokTakipContext();

        // GET: Yetki
        public ActionResult Index(string aranacakYetki)
        {
            List<Yetki> yetkiler = db.Yetkis.ToList();
            if (!string.IsNullOrEmpty(aranacakYetki))
            {
                yetkiler = yetkiler.Where(x => x.YetkiAdi.ToLower().Contains(aranacakYetki.ToLower())).ToList();
            }
            return View(yetkiler);
        }

        // Yetki Ekle

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Yetki pYtk)
        {
            Yetki ytk = new Yetki();
            ytk.YetkiAdi = pYtk.YetkiAdi;
            ytk.YetkiAciklama = pYtk.YetkiAciklama;
            ytk.YetkiDurum = true;

            db.Yetkis.Add(ytk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Yetki Sil

        public ActionResult Sil(int id)
        {
            Yetki ytk = db.Yetkis.Find(id);
            ytk.YetkiDurum = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        // Yetki Güncelle

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Yetki ytk = db.Yetkis.Find(id);

            return View(ytk);
        }

        [HttpPost]
        public ActionResult Guncelle(Yetki pYtk)
        {
            Yetki ytk = db.Yetkis.Find(pYtk.YetkiId);
            ytk.YetkiAdi = pYtk.YetkiAdi;
            ytk.YetkiAciklama = pYtk.YetkiAciklama;
            ytk.YetkiDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}