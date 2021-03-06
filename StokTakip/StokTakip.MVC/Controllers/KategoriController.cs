using StokTakip.Entities.Model;
using StokTakip.MVC.Models;
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
        public ActionResult Index(string aranacakKtgr)
        {
            try
            {
                List<Kategori> kategoriler = db.Kategoris.ToList();
                if (!string.IsNullOrEmpty(aranacakKtgr))
                {
                    kategoriler = kategoriler.Where(x => x.KategoriAdi.ToLower().Contains(aranacakKtgr.ToLower())).ToList();
                }
                return View(kategoriler);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Login");
            }

        }

        // Kategori Ekle

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Kategori pKtgr)
        {
            pKtgr.KategoriDurum = true;
            db.Kategoris.Add(pKtgr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Kategori Sil

        public ActionResult Sil(int id)
        {
            Kategori ktgr = db.Kategoris.Find(id);
            ktgr.KategoriDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Kategori Güncelle

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Kategori ktgr = db.Kategoris.Find(id);
            return View(ktgr);
        }

        [HttpPost]
        public ActionResult Guncelle(Kategori pKtgr)
        {
            Kategori ktgr = db.Kategoris.Find(pKtgr.KategoriId);
            ktgr.KategoriAdi = pKtgr.KategoriAdi;
            ktgr.KategoriAciklama = pKtgr.KategoriAciklama;
            ktgr.KategoriDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}