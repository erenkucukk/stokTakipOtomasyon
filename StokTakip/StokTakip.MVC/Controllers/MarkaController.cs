using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class MarkaController : Controller
    {
        StokTakipContext db = new StokTakipContext();

        // GET: Marka
        public ActionResult Index(string aranacakMarka)
        {
            List<Marka> markalar = db.Markas.ToList();
            if (!string.IsNullOrEmpty(aranacakMarka))
            {
                markalar = markalar.Where(x => x.MarkaAdi.ToLower().Contains(aranacakMarka.ToLower())).ToList();
            }
            return View(markalar);
        }

        // Marka Ekle

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Marka pMrk)
        {
            pMrk.MarkaDurum = true;

            db.Markas.Add(pMrk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Marka Sil

        public ActionResult Sil(int id)
        {
            Marka mrk = db.Markas.Find(id);
            mrk.MarkaDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Marka Güncelle

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Marka mrk = db.Markas.Find(id);
            return View(mrk);
        }

        [HttpPost]
        public ActionResult Guncelle(Marka pMrk)
        {
            Marka mrk = db.Markas.Find(pMrk.MarkaId);
            mrk.MarkaAdi = pMrk.MarkaAdi;
            mrk.MarkaAciklama = pMrk.MarkaAciklama;

            mrk.MarkaDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}