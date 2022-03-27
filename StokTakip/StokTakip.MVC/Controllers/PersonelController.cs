using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class PersonelController : Controller
    {
        StokTakipContext db = new StokTakipContext();

        // GET: Personel

        public ActionResult Index()
        {
            List<Personel> personeller = db.Personels.ToList();
            return View(personeller);
        }
        
        // Personel Ekle

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Personel pPers)
        {
            pPers.PersonelDurum = true;
            db.Personels.Add(pPers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Personel Sil

        public ActionResult Sil(int id)
        {
            Personel pers = db.Personels.Find(id);
            pers.PersonelDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Personel Güncelle
        
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Personel pers = db.Personels.Find(id);

            return View(pers);
        }

        [HttpPost]
        public ActionResult Guncelle(Personel pPers)
        {
            Personel pers = db.Personels.Find(pPers.PersonelId);
            pers.PersonelAdi = pPers.PersonelAdi;
            pers.PersonelSoyadi = pPers.PersonelSoyadi;
            pers.DogumTarihi = pPers.DogumTarihi;
            pers.Fotograf = pPers.Fotograf;
            pers.PersonelKAdi = pPers.PersonelKAdi;
            pers.PersonelMail = pPers.PersonelMail;
            pers.YetkiId = pPers.YetkiId;
            pers.PersonelDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}