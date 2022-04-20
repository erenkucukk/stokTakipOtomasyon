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
        public ActionResult Index()
        {
            List<StokHareket> stokHareketler = db.StokHarekets.Where(x => x.Durum).ToList();
            return View(stokHareketler);

        }

        //Stok Giriş

        [HttpGet]
        public ActionResult StokGiris(int id)
        {
            StokHareket stk = db.StokHarekets.Find(id);

            List<SelectListItem> urunler = db.Uruns.Where(x => x.UrunDurum== true)
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

        [HttpPost]
        public ActionResult StokGiris(StokHareket pStokHareket)
        {
            using (StokTakipContext db = new StokTakipContext())
            {
                StokHareket stkHrkt = new StokHareket();
                stkHrkt.Urun = db.Uruns.Where(x => x.UrunId == pStokHareket.UrunId).FirstOrDefault();
                stkHrkt.Tarih = DateTime.Now;
                stkHrkt.Durum = true;
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
                stkHrkt.Personel = db.Personels.Where(x => x.PersonelId == pStokHareket.PersonelId).FirstOrDefault();
                db.StokHarekets.Add(stkHrkt);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}