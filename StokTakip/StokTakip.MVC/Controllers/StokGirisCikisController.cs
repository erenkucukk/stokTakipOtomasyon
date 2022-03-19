using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class StokGirisCikisController : Controller
    {
        StokTakipContext db = new StokTakipContext();

        // GET: StokGirisCikis
        public ActionResult Index()
        {
            List<StokGirisCikis> stokGirisCikislar = db.StokGirisCikiss.Where(x => x.UrunDurum).ToList();
            return View(stokGirisCikislar);
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

            List<SelectListItem> kategoriler = db.Kategoris.AsNoTracking().Where(b => b.KategoriDurum == true)
                                            .Select(s => new SelectListItem
                                            {
                                                Value = s.KategoriId.ToString(),
                                                Text = s.KategoriAdi
                                            }).ToList();

            ViewBag.Kategoriler = kategoriler;
            ViewBag.Birimler = birimler;
            return View();

        }

        [HttpPost]
        public ActionResult Ekle(StokGirisCikis pGrsCks)
        {
            pGrsCks.UrunDurum = true;

            pGrsCks.Birim = db.Birims.Find(pGrsCks.UrunBirimId);
            pGrsCks.Kategori = db.Kategoris.Find(pGrsCks.UrunKategoriId);

            db.StokGirisCikiss.Add(pGrsCks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Sil

        public ActionResult Sil(int id)
        {
            StokGirisCikis grsCks = db.StokGirisCikiss.Find(id);
            grsCks.UrunDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Marka Güncelle

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            StokGirisCikis grsCks = db.StokGirisCikiss.Find(id);

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

            ViewBag.Kategoriler = kategoriler;
            ViewBag.Birimler = birimler;

            return View(grsCks);
        }

        [HttpPost]
        public ActionResult Guncelle(StokGirisCikis pGrsCks)
        {
            StokGirisCikis grsCks = db.StokGirisCikiss.Find(pGrsCks.UrunStokKodu);
            grsCks.UrunAciklama = pGrsCks.UrunAciklama;
            grsCks.UrunBirimId = pGrsCks.UrunBirimId;
            grsCks.UrunMiktar = pGrsCks.UrunMiktar;
            grsCks.UrunKategoriId = pGrsCks.UrunKategoriId;
            grsCks.UrunAlisFiyat = pGrsCks.UrunAlisFiyat;
            grsCks.UrunToplamFiyat = pGrsCks.UrunToplamFiyat;
            grsCks.StokPersonel = pGrsCks.StokPersonel;
            grsCks.UrunDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}