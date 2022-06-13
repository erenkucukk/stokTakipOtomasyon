using StokTakip.Entities.Model;
using StokTakip.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class UrunController : Controller
    {
        StokTakipContext db = new StokTakipContext();

        // GET: Urun 
        public ActionResult Index(string aranacakUrun)
        {
            List<Urun> urunler = db.Uruns.ToList();
            if (!string.IsNullOrEmpty(aranacakUrun))
            {
                urunler = urunler.Where(x => x.UrunAdi.ToLower().Contains(aranacakUrun.ToLower())).ToList();
            }
            return View(urunler);
        }


        public ActionResult Raporlama()
        {
            List<Urun> urunler = db.Uruns.ToList();
            return View(urunler);
        }

        // Ekle

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> birimler = db.Birims.AsNoTracking().Where(b => b.BirimDurum == true)
                                            .Select(s => new SelectListItem
                                            {
                                                Value = s.BirimId.ToString(),
                                                Text = s.BirimAdi
                                            }).ToList();

            List<SelectListItem> kategoriler = db.Kategoris.Where(x => x.KategoriDurum == true)
                                            .Select(s => new SelectListItem
                                            {
                                                Value = s.KategoriId.ToString(),
                                                Text = s.KategoriAdi
                                            }).ToList();

            List<SelectListItem> markalar = db.Markas.AsNoTracking().Where(b => b.MarkaDurum == true)
                                            .Select(s => new SelectListItem
                                            {
                                                Value = s.MarkaId.ToString(),
                                                Text = s.MarkaAdi
                                            }).ToList();

            ViewBag.Kategoriler = kategoriler;
            ViewBag.Birimler = birimler;
            ViewBag.Markalar = markalar;
            return View();

        }

        [HttpPost]
        public ActionResult Ekle(Urun pUrun)
        {
            pUrun.UrunDurum = true;

            pUrun.Birim = db.Birims.Find(pUrun.UrunBirimId);
            pUrun.Kategori = db.Kategoris.Find(pUrun.UrunKategoriId);
            pUrun.Marka = db.Markas.Find(pUrun.UrunMarkaId);

            db.Uruns.Add(pUrun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // Urun Güncelle

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Urun urun = db.Uruns.Find(id);

            List<SelectListItem> birimler = db.Birims.AsNoTracking().Where(b => b.BirimDurum == true)
                                            .Select(s => new SelectListItem
                                            {
                                                Value = s.BirimId.ToString(),
                                                Text = s.BirimAdi
                                            }).ToList();

            List<SelectListItem> kategoriler = db.Kategoris.AsNoTracking().Where(b => b.KategoriDurum == true)
                                            .Select(s => new SelectListItem
                                            {
                                                Value = s.KategoriId.ToString(),
                                                Text = s.KategoriAdi
                                            }).ToList();

            List<SelectListItem> markalar = db.Markas.AsNoTracking().Where(b => b.MarkaDurum == true)
                                            .Select(s => new SelectListItem
                                            {
                                                Value = s.MarkaId.ToString(),
                                                Text = s.MarkaAdi
                                            }).ToList();

            ViewBag.Kategoriler = kategoriler;
            ViewBag.Birimler = birimler;
            ViewBag.Markalar = markalar;

            return View(urun);
        }

        [HttpPost]
        public ActionResult Guncelle(Urun pUrun)
        {
            Urun urun = db.Uruns.Find(pUrun.UrunId);
            urun.UrunAciklama = pUrun.UrunAciklama;
            urun.UrunAdi = pUrun.UrunAdi;
            urun.UrunAdi = pUrun.UrunAdi;
            urun.UrunMarkaId = pUrun.UrunMarkaId;
            urun.UrunMiktar = pUrun.UrunMiktar;
            urun.UrunKategoriId = pUrun.UrunKategoriId;
            urun.UrunSatisFiyat = pUrun.UrunSatisFiyat;
            urun.UrunDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}