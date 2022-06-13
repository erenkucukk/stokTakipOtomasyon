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
        public ActionResult Index(string aranacaAltKtgr)
        {
            List<AltKategori> altkategoriler = db.AltKategoris.ToList();
            if (!string.IsNullOrEmpty(aranacaAltKtgr))
            {
                altkategoriler = altkategoriler.Where(x => x.AltKategoriAdi.ToLower().Contains(aranacaAltKtgr.ToLower())).ToList();
            }
            return View(altkategoriler);
        }

        // Alt Kategori Ekle

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> kategoriler = db.Kategoris.AsNoTracking().Where(b => b.KategoriDurum == true)
                                   .Select(s => new SelectListItem
                                   {
                                       Value = s.KategoriId.ToString(),
                                       Text = s.KategoriAdi
                                   }).ToList();
            ViewBag.Kategoriler = kategoriler;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(AltKategori pAltKtgr)
        {
            pAltKtgr.AltKategoriDurum = true;

            pAltKtgr.Kategori = db.Kategoris.Find(pAltKtgr.KategoriId);

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

            List<SelectListItem> kategoriler = db.Kategoris.AsNoTracking().Where(b => b.KategoriDurum == true)
                                            .Select(s => new SelectListItem
                                            {
                                                Value = s.KategoriId.ToString(),
                                                Text = s.KategoriAdi
                                            }).ToList();

            ViewBag.Kategoriler = kategoriler;

            return View(altKtgr);
        }

        [HttpPost]
        public ActionResult Guncelle(AltKategori pAltKtgr)
        {
            AltKategori altKtgr = db.AltKategoris.Find(pAltKtgr.AltKategoriId);
            altKtgr.AltKategoriAdi = pAltKtgr.AltKategoriAdi;
            altKtgr.AltKategoriAciklama = pAltKtgr.AltKategoriAciklama;
            altKtgr.KategoriId = pAltKtgr.KategoriId;
            altKtgr.AltKategoriDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}