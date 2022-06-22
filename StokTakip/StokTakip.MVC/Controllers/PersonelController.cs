using StokTakip.Entities.Model;
using StokTakip.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class PersonelController : Controller
    {
        StokTakipContext db = new StokTakipContext();

        // GET: Personel

        public ActionResult Index(string aranacakPersonel)
        {
            List<Personel> personeller = db.Personels.ToList();
            if (!string.IsNullOrEmpty(aranacakPersonel))
            {
                personeller = personeller.Where(x => x.PersonelAdi.ToLower().Contains(aranacakPersonel.ToLower()) || x.PersonelSoyadi.ToLower().Contains(aranacakPersonel.ToLower())).ToList();
            }
            return View(personeller);
        }
        
        // Personel Ekle

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> yetkiler = db.Yetkis.AsNoTracking().Where(b => b.YetkiDurum == true)
                       .Select(s => new SelectListItem
                       {
                           Value = s.YetkiId.ToString(),
                           Text = s.YetkiAdi
                       }).ToList();
            ViewBag.Yetkiler = yetkiler;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Personel pPers)
        {
            pPers.PersonelDurum = true;
            pPers.PersonelSifre = SifreOlusturma.Olustur(8);
            

            string mail = pPers.PersonelMail;
            string subject = "Stok Takip Sistemimize hoşgeldin " + pPers.PersonelAdi;
            string body = "Tek kullanımlık şifreniz : " + pPers.PersonelSifre;
            MailGonderClass.MailGonder(mail,subject,body);

            db.Personels.Add(pPers);
            db.SaveChanges();



            return RedirectToAction("Index");

          
        }



        // Personel Sil

        public ActionResult Sil(int id)
        {

            Personel pers = db.Personels.Find(id);
            pers.PersonelDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Personel Güncelle
        
        [HttpGet]
        public ActionResult Guncelle(int id)
        {

            Personel pers = db.Personels.Find(id);

            List<SelectListItem> yetkiler = db.Yetkis.AsNoTracking().Where(b => b.YetkiDurum == true)
                                            .Select(s => new SelectListItem
                                            {
                                                Value = s.YetkiId.ToString(),
                                                Text = s.YetkiAdi
                                            }).ToList();

            ViewBag.Yetkiler = yetkiler;


            return View(pers);
        }

        [HttpPost]
        public ActionResult Guncelle(Personel pPers)
        {
            Personel pers = db.Personels.Find(pPers.PersonelId);
            pers.PersonelAdi = pPers.PersonelAdi;
            pers.PersonelSoyadi = pPers.PersonelSoyadi;
            pers.DogumTarihi = pPers.DogumTarihi;
            pers.Fotograf = pPers.Fotograf;
            pers.PersonelKAdi = pPers.PersonelKAdi;
            pers.PersonelMail = pPers.PersonelMail;
            pers.YetkiId = pPers.YetkiId;
            pers.Telefon = pPers.Telefon;
            pers.PersonelDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}