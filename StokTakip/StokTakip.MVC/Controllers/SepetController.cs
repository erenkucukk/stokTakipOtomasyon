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



            //Sepet sepet = new Sepet();
            //List<Sepet> sepetler = db.Sepets.Where(x => x.SepetDurum).ToList();


            //Tutar = db.Sepets.Sum(x => x.ToplamFiyat);
            //ViewBag.Tutar = "Toplam tutar: " + Tutar + "₺";

            //return View(model);




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
                    return RedirectToAction("Index", "Urun");
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
                return RedirectToAction("Index","Urun");
            }
            return HttpNotFound();

        }

        public ActionResult Sil(int id)
        {
            db.Sepets.Remove(db.Sepets.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SeciliSil(FormCollection form)
        {
            string[] seciliId = form["secim_id"].Split(new char[] { ',' });
            foreach (string id in seciliId)
            {
                Sepet model = db.Sepets.Find(int.Parse(id));
                db.Sepets.Remove(model);
                db.SaveChanges();
            }



            return RedirectToAction("Index");
        }

        /*
         public ActionResult HepsiniSil()
         {
             db.Sepets.RemoveRange(db.Sepets);
             db.SaveChanges();
             return RedirectToAction("Index");


         }*/

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

        [HttpPost]
        public ActionResult SeciliSat(List<Sepet> data = null)
        {
            string[] ids = data.Select(x => x.SepetId.ToString()).ToArray();
            decimal total = 0;
            foreach (var item in ids)
            {
                var model = db.Sepets.Find(int.Parse(item));
                if (int.Parse(item) != 0)
                {
                    total += model.ToplamFiyat;
                }

            }
            ViewBag.Total = total.ToString("0.00") + " ₺";
            return View(data);
        }

        [HttpPost]
        public ActionResult SeciliSat2(int[] ids)
        {
            StokHareket stkHrkt = new StokHareket();
            var model = db.Sepets.Where(x => ids.Contains(x.SepetId)).ToList();
            int row = 0;
            foreach (var item in model)
            {
                var satis = new Satis
                {
                    PersonelNo = model[row].PersonelNo,
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
                    PersonelId = model[row].PersonelNo,
                    Tarih = DateTime.Now

                };


                db.StokHarekets.Add(stkHareket);
                row++;
            }


            db.Sepets.RemoveRange(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}