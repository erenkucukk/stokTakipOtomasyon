using PagedList;
using StokTakip.Entities.Model;
using StokTakip.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class StokHareketController : Controller
    {
        StokTakipContext db = new StokTakipContext();

        // GET: StokHareket
        public ActionResult Index(string aranacakHareket)
        {
            List<StokHareket> stokHareketler = db.StokHarekets.ToList();
            if (!string.IsNullOrEmpty(aranacakHareket))
            {
                stokHareketler = stokHareketler.Where(x => x.Urun.UrunAdi.ToLower().Contains(aranacakHareket.ToLower())).ToList();
            }

            return View(stokHareketler);


        }

        public ActionResult Raporlama()
        {
            List<StokHareket> stokHareketler = db.StokHarekets.ToList();
            return View(stokHareketler);
        }

        //Stok Giriş

        [HttpGet]
        public ActionResult StokGiris(int id)
        {
            StokHareket stk = db.StokHarekets.Find(id);
            Personel pers = new Personel();

            if (pers.YetkiId == 1 || pers.YetkiId == 3)
            {
                List<SelectListItem> urunler = db.Uruns.Where(x => x.UrunDurum == true)
                        .Select(s => new SelectListItem
                        {
                            Value = s.UrunId.ToString(),
                            Text = s.UrunAdi
                        }).ToList();

                List<SelectListItem> personeller = db.Personels.Where(x => x.PersonelDurum == true)
                                    .Select(s => new SelectListItem
                                    {
                                        Value = s.PersonelId.ToString(),
                                        Text = s.PersonelAdi + " " + s.PersonelSoyadi
                                    }).ToList();

                ViewBag.Personeller = personeller;
                ViewBag.Urunler = urunler;
                return View(stk);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult StokGiris(StokHareket pStokHareket)
        {
            using (StokTakipContext db = new StokTakipContext())
            {
                StokHareket stkHrkt = new StokHareket();
                stkHrkt.Urun = db.Uruns.Where(x => x.UrunId == pStokHareket.UrunId).FirstOrDefault();
                stkHrkt.Tarih = DateTime.Now;
                stkHrkt.Durum = true;
                stkHrkt.PersonelId = int.Parse(Session["PersonelId"].ToString());
                stkHrkt.UrunAlisFiyat += pStokHareket.UrunAlisFiyat;
                stkHrkt.Urun.UrunMiktar += pStokHareket.UrunMiktar;
                stkHrkt.UrunSonFiyat = pStokHareket.UrunMiktar * stkHrkt.UrunAlisFiyat;
                stkHrkt.UrunMiktar += pStokHareket.UrunMiktar;
                stkHrkt.Personel = db.Personels.Where(x => x.PersonelId == pStokHareket.PersonelId).FirstOrDefault();
                stkHrkt.HareketTipi = true;
                db.StokHarekets.Add(stkHrkt);
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        // Stok Çıkış

        [HttpGet]
        public ActionResult StokCikis(int id)
        {
            StokHareket stk = db.StokHarekets.Find(id);

            Personel pers = new Personel();

            if (pers.YetkiId == 1 || pers.YetkiId == 4)
            {
                List<SelectListItem> urunler = db.Uruns.Where(x => x.UrunDurum == true)
                    .Select(s => new SelectListItem
                    {
                        Value = s.UrunId.ToString(),
                        Text = s.UrunAdi
                    }).ToList();

                List<SelectListItem> personeller = db.Personels.Where(x => x.PersonelDurum == true)
                                    .Select(s => new SelectListItem
                                    {
                                        Value = s.PersonelId.ToString(),
                                        Text = s.PersonelAdi + " " + s.PersonelSoyadi
                                    }).ToList();

                ViewBag.Personeller = personeller;
                ViewBag.Urunler = urunler;
                return View(stk);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult StokCikis(StokHareket pStokHareket)
        {
            using (StokTakipContext db = new StokTakipContext())
            {
                StokHareket stkHrkt = new StokHareket();
                stkHrkt.Urun = db.Uruns.Where(x => x.UrunId == pStokHareket.UrunId).FirstOrDefault();
                stkHrkt.Tarih = DateTime.Now;
                stkHrkt.Durum = true;
                stkHrkt.UrunSatisFiyat = pStokHareket.UrunSatisFiyat;
                stkHrkt.Iskonto = pStokHareket.Iskonto;
                stkHrkt.UrunSonFiyat = pStokHareket.UrunMiktar * pStokHareket.UrunSatisFiyat - pStokHareket.UrunMiktar * pStokHareket.UrunSatisFiyat * stkHrkt.Iskonto / 100;
                stkHrkt.Urun.UrunMiktar -= pStokHareket.UrunMiktar;
                stkHrkt.UrunMiktar += pStokHareket.UrunMiktar;
                stkHrkt.HareketTipi = false;
                stkHrkt.PersonelId = int.Parse(Session["PersonelId"].ToString());
                stkHrkt.Personel = db.Personels.Where(x => x.PersonelId == pStokHareket.PersonelId).FirstOrDefault();
                db.StokHarekets.Add(stkHrkt);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetById(int id)
        {
            using(StokTakipContext db = new StokTakipContext())
            {

                List<StokHareket> stokHareketler = db.StokHarekets.Where(x => x.UrunId == id).ToList();

                foreach (var stkHrkt in stokHareketler)
                {
                    stkHrkt.Urun = db.Uruns.Where(x=>x.UrunId == stkHrkt.UrunId).FirstOrDefault();
                    stkHrkt.Personel = db.Personels.Where(x=>x.PersonelId == stkHrkt.PersonelId).FirstOrDefault();
                }

                return View(stokHareketler);
            }
        }
        public ActionResult Sil(int id)
        {
            StokHareket hrkt = db.StokHarekets.Find(id);
            db.StokHarekets.Remove(hrkt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}