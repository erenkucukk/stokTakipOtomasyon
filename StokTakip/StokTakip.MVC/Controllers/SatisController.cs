using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class SatisController : Controller
    {
        StokTakipContext db = new StokTakipContext();
        // GET: Satis
        public ActionResult Index()
        {
            List<Satis> satislar = db.Satiss.ToList();
            return View(satislar);
        }

        public ActionResult Raporlama()
        {
            List<Satis> satislar = db.Satiss.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult HepsiniSat(decimal? Tutar)
        {

            var model = db.Sepets.ToList();


            var kid = db.Sepets.FirstOrDefault();
            if (model != null)
            {
                if (kid == null)
                {
                    ViewBag.Tutar = "Sepetinizde ürün bulunamamıştır.";
                }
                else if (kid != null)
                {
                    Tutar = db.Sepets.Where(x => x.PersonelNo == kid.PersonelNo).Sum(x => x.ToplamFiyat);
                    ViewBag.Tutar = "Toplam tutar : " + Tutar + "₺";
                }
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult HepsiniSat(StokHareket pStokHareket)
        {
            StokHareket stkHrkt = new StokHareket();

            var model = db.Sepets.ToList();

            int row = 0;
            foreach (var item in model)
            {
                var satis = new Satis
                {
                    SiparisNo = 0,
                    PersonelNo = int.Parse(Session["PersonelId"].ToString()),
                    UrunNo = model[row].UrunNo,
                    SepetNo = model[row].SepetId,
                    BarkodNo = model[row].Urun.UrunId,
                    BirimFiyat = model[row].BirimFiyat,
                    Miktar = model[row].Miktar,
                    ToplamFiyat = model[row].ToplamFiyat,
                    //Iskonto = spt.Iskonto,
                    BirimNo = model[row].Urun.UrunBirimId,
                    Tarih = DateTime.Now

                };

                db.Satiss.Add(satis);
                row++;
            }
            foreach (var item in model)
            {
                var urun = db.Uruns.FirstOrDefault(x => x.UrunId == item.UrunNo);
                if (urun != null)
                {
                    urun.UrunMiktar = urun.UrunMiktar - item.Miktar;
                }
            }
            row = 0;
            foreach (var item in model)
            {
                var stkHareket = new StokHareket
                {
                    UrunId = model[row].UrunNo,
                    HareketTipi = false,
                    Durum = true,
                    UrunSatisFiyat = model[row].BirimFiyat,
                    UrunSonFiyat = model[row].Miktar * model[row].BirimFiyat - model[row].Miktar * model[row].BirimFiyat * stkHrkt.Iskonto / 100,
                    UrunMiktar = model[row].Miktar,
                    //Iskonto = spt.Iskonto,
                    PersonelId = int.Parse(Session["PersonelId"].ToString()),
                    Tarih = DateTime.Now

                };

                db.StokHarekets.Add(stkHareket);
                row++;
            }

            db.Sepets.RemoveRange(model);
            db.SaveChanges();

            return RedirectToAction("Index", "Sepet");
        }


        /* [HttpGet]
         public ActionResult Sat(int id)
         {
             Sepet spt = db.Sepets.Find(id);
             return View(spt);
         }

         [HttpPost]
         public ActionResult Sat(Sepet pSepet)
         {
             try
             {
                 Sepet spt = db.Sepets.Find(pSepet.SepetId);
                 StokHareket stkHrkt = new StokHareket();
                 //var model = db.Sepets.FirstOrDefault(x => x.SepetId == pSepet.SepetId); --> bu sekilde de olur
                 var satis = new Satis
                 {
                     PersonelNo = spt.PersonelNo,
                     UrunNo = spt.UrunNo,
                     SepetNo = spt.SepetId,
                     BarkodNo = spt.Urun.UrunId,
                     BirimFiyat = spt.BirimFiyat,
                     Miktar = spt.Miktar,
                     ToplamFiyat = spt.ToplamFiyat,
                     //Iskonto = spt.Iskonto,
                     BirimNo = spt.Urun.UrunBirimId,
                     Tarih = DateTime.Now
                 };
                 db.Sepets.Remove(spt);
                 db.Satiss.Add(satis);
                 db.SaveChanges();
                 return RedirectToAction("Index");


             }
             catch (Exception)
             {

                 ViewBag.islem = "Satış işlemi başarısız!";
             }

             return View("islem");



         }
        */

        public ActionResult Sil(int id)
        {
            Satis sts = db.Satiss.Find(id);
            db.Satiss.Remove(sts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}