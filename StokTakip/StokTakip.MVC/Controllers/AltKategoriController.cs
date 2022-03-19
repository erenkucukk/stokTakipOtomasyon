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
            List<AltKategori> altkategoriler = db.AltKategoris.Where(x => x.AltKategoriDurum == true).ToList();
            return View(altkategoriler);
        }

        // Alt Kategori Ekle

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(AltKategori pAltKtgr)
        {
            pAltKtgr.AltKategoriDurum = true;
            db.AltKategoris.Add(pAltKtgr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Alt Kategori Sil

        public ActionResult Sil(int id)
        {
            AltKategori altKtgr = db.AltKategoris.Find(id);
            altKtgr.AltKategoriDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Alt Kategori Güncelle

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            AltKategori altKtgr = db.AltKategoris.Find(id);
            return View(altKtgr);
        }

        [HttpPost]
        public ActionResult Guncelle(AltKategori pAltKtgr)
        {
            AltKategori altKtgr = db.AltKategoris.Find(pAltKtgr.AltKategoriId);
            altKtgr.AltKategoriAdi = pAltKtgr.AltKategoriAdi;
            altKtgr.AltKategoriAciklama = pAltKtgr.AltKategoriAciklama;
            altKtgr.AltKategoriDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}