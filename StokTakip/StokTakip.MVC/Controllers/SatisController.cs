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

        [HttpGet]
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
    }
}