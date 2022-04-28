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



            Sepet sepet = new Sepet();
            //List<Sepet> sepetler = db.Sepets.Where(x => x.SepetDurum).ToList();


            Tutar = db.Sepets.Sum(x => x.ToplamFiyat);
            ViewBag.Tutar = "Toplam tutar: " + Tutar + "₺";

            return View(model);




        }
        public ActionResult Ekle(int id)
        {

            var model = db.Personels.FirstOrDefault();
            var u = db.Uruns.Find(id);
            var sepet = db.Sepets.FirstOrDefault(x => x.PersonelNo == model.PersonelId && x.UrunNo == id);
            if (model != null)
            {
                if (sepet != null)
                {
                    sepet.Miktar++;
                    sepet.ToplamFiyat = sepet.Miktar * sepet.BirimFiyat;
                    sepet.SepetDurum = true;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                var s = new Sepet
                {
                    PersonelNo = model.PersonelId,
                    UrunNo = u.UrunId,
                    Miktar = 1,
                    BirimFiyat = u.UrunSatisFiyat,
                    ToplamFiyat = u.UrunSatisFiyat,
                    Tarih = DateTime.Now,
                    SepetDurum = true
                };
                db.Entry(s).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();

        }

        public ActionResult Sil(int id)
        {
            db.Sepets.Remove(db.Sepets.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HepsiniSil()
        {
            db.Sepets.RemoveRange(db.Sepets);
            db.SaveChanges();
            return RedirectToAction("Index");
            
            
        }

        public ActionResult ToplamSayi(int? count)
        {


            count = db.Sepets.Count();
            ViewBag.Count = count;
            if (count == 0)
            {
                ViewBag.Count = "";
            }
            return PartialView();


        }

        public ActionResult Arttir(int id)
        {
            var model = db.Sepets.Find(id);
            model.Miktar++;
            model.ToplamFiyat = model.BirimFiyat * model.Miktar;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Azalt(int id)
        {
            var model = db.Sepets.Find(id);
            if (model.Miktar == 1)
            {
                db.Sepets.Remove(model);
                db.SaveChanges();
            }
            model.Miktar--;
            model.ToplamFiyat = model.BirimFiyat * model.Miktar;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void DinamikMiktar(int id, int miktari)
        {
            var model = db.Sepets.Find(id);
            if (miktari > 0)
            {
                model.Miktar = miktari;
                model.ToplamFiyat = model.BirimFiyat * model.Miktar;
                db.SaveChanges();
            }

        }

    }
}