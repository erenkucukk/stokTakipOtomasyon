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
        public ActionResult Index(string aranacakBirim)
        {
            List<Birim> birimler = db.Birims.ToList();
            if (!string.IsNullOrEmpty(aranacakBirim))
            {
                birimler = birimler.Where(x => x.BirimAdi.ToLower().Contains(aranacakBirim.ToLower())).ToList();
            }
            return View(birimler);
        }


        // Birim Ekle

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Birim pBrm)
        {
            Birim brm = new Birim();
            brm.BirimAdi = pBrm.BirimAdi;
            brm.BirimAciklama = pBrm.BirimAciklama;
            brm.BirimDurum = true;

            db.Birims.Add(brm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Birim Sil

        public ActionResult Sil(int id)
        {
            Birim brm = db.Birims.Find(id);
            brm.BirimDurum = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        // Birim Güncelle

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Birim brm = db.Birims.Find(id);
            return View(brm);
        }

        [HttpPost]
        public ActionResult Guncelle(Birim pBrm)
        {
            Birim brm = db.Birims.Find(pBrm.BirimId);
            brm.BirimAdi = pBrm.BirimAdi;
            brm.BirimAciklama = pBrm.BirimAciklama;
            brm.BirimDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}