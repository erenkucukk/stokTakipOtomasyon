using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class UyeController : Controller
    {
        StokTakipContext db = new StokTakipContext();
        // GET: Uye
        public ActionResult Index()
        {
            /* AsNoTracking
             * mapping yapmadığı için daha hızlı çalışmayı sağlıyo
             * update insert delete yapmıycaksak kullanalım */

            var uyeler = db.Uyes.AsNoTracking();
            return View(uyeler.ToList());
        }

        // Uye Ekle

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Uye pUye)
        {
            pUye.UyeDurum = true;

            db.Uyes.Add(pUye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Uye Sil
        [HttpGet]
        public ActionResult Sil(int id)
        {
            Uye uye = db.Uyes.Find(id);
            uye.UyeDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Uye Güncelle

        [HttpGet] 
        public ActionResult Guncelle(int id)
        {
            Uye uye = db.Uyes.Find(id);
            return View(uye);
        }

        [HttpPost]
        public ActionResult Guncelle(Uye pUye)
        {
            Uye uye = db.Uyes.Find(pUye.UyeId);
            uye.UyeAdi = pUye.UyeAdi;
            uye.UyeSoyadi = pUye.UyeSoyadi;
            uye.UyeTelefon = pUye.UyeTelefon;
            uye.Cinsiyet = pUye.Cinsiyet;
            uye.UyeDogumTarihi = pUye.UyeDogumTarihi;
            uye.UyeMail = pUye.UyeMail;
            uye.UyeResim = pUye.UyeResim;
            uye.UyeDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}