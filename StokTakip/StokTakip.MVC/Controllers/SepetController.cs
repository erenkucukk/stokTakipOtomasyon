using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class SepetController : Controller
    {
        StokTakipContext db = new StokTakipContext();
        // GET: Sepet
        public ActionResult Index(decimal? Tutar)
        {

            var model = db.Sepets.ToList();
            var kid = db.Sepets.FirstOrDefault();

            if (kid == null)
            {
                ViewBag.Tutar = "Sepetinizde ürün bulunamamıştır.";
            }
            else if (kid != null)
            {
                Tutar = db.Sepets.Sum(x => x.ToplamFiyat);
                ViewBag.Tutar = "Toplam tutar: " + Tutar + "TL";
            }
            return View(model);

            /*
                var kullanici = db.Personels.FirstOrDefault();
                var model = db.Sepets.Where(x => x.PersonelNo == kullanici.PersonelId).ToList();
                var kid = db.Sepets.FirstOrDefault(x => x.PersonelNo == kullanici.PersonelId);

                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün bulunamamıştır.";
                    }
                    else if (kid != null)
                    {
                        Tutar = db.Sepets.Where(x => x.PersonelNo == kid.PersonelNo).Sum(x => x.ToplamFiyat);
                        ViewBag.Tutar = "Toplam tutar" + Tutar + "TL";
                    }
                    return View(model);
                */





            /*            if (User.Identity.IsAuthenticated)
             {
                 var kullaniciadi = User.Identity.Name;
                 var kullanici = db.Personels.FirstOrDefault(x => x.PersonelAdi == kullaniciadi);
                 var model = db.Sepets.Where(x => x.PersonelNo == kullanici.PersonelId).ToList();
                 var kid = db.Sepets.FirstOrDefault(x => x.PersonelNo == kullanici.PersonelId);
                 if (model != null)
                 {
                     if (kid == null)
                     {
                         ViewBag.Tutar = "Sepetinizde ürün bulunamamıştır.";
                     }
                     else if (kid != null)
                     {
                         Tutar = db.Sepets.Where(x => x.PersonelNo == kid.PersonelNo).Sum(x => x.ToplamFiyat);
                         ViewBag.Tutar = "Toplam tutar" + Tutar + "TL";
                     }
                     return View(model);
                 }
             } Sepet spt = new Sepet();
             List<Sepet> sepetler = db.Sepets.Where(x => x.SepetDurum).ToList();
             //Tutar = Sum(x=>x.)
             ViewBag.Tutar = spt.ToplamFiyat;
             Tutar = db.Sepets.Where(PersonelNo ==db.Sepets.Where(Personel.PersonelId).Sum(x=>x.ToplamFiyat);*/

        }
    }
}