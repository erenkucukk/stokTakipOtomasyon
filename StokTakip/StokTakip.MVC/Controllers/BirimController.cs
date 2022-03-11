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


        // Birim Sil

        public ActionResult Sil(int id)
        {
            Birim brm = db.Birims.Find(id);
            brm.BirimDurum = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        // Birim Ekle
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Birim pbrm)
        {
            Birim brm = new Birim();
            brm.BirimAdi = pbrm.BirimAdi;
            brm.BirimAciklama = pbrm.BirimAciklama;
            brm.BirimDurum = true;

            db.Birims.Add(brm);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // Birim Güncelle

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Birim brm = db.Birims.Find(id);
            return View(brm);
        }

        [HttpPost]
        public ActionResult Guncelle(Birim pbrm)
        {
            Birim brm = db.Birims.Find(pbrm.BirimId);
            brm.BirimAdi = pbrm.BirimAdi;
            brm.BirimAciklama = pbrm.BirimAciklama;
            brm.BirimDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}