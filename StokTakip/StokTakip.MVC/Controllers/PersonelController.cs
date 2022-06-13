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
           /* MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("erendenemehesabi@hotmail.com", "aishklmnuoE");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesajim.To.Add("erendenemehesabi@hotmail.com");
            mesajim.From = new MailAddress("erendenemehesabi@hotmail.com");
            mesajim.Subject = "Şifre yenileme isteği";
            mesajim.Body = "Şifre yenileme isteği";
            istemci.Send(mesajim);

            return RedirectToAction("Index");*/


            /*
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("erenyenidenemehesabi@hotmail.com", "tscgdoe84ls0_ > @lsk746 % _");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesajim.To.Add("erenyenidenemehesabi@hotmail.com");
            mesajim.From = new MailAddress("erenyenidenemehesabi@hotmail.com");
            mesajim.Subject = "Şifre yenileme isteği";
            mesajim.Body = "Merhaba";
            istemci.Send(mesajim);
            return RedirectToAction("Index");
            */
            /* pPers.PersonelDurum = true;
             Guid rastgele = Guid.NewGuid();
             pPers.PersonelSifre = rastgele.ToString().Substring(0, 8);
             db.Personels.Add(pPers);
             db.SaveChanges();
             SmtpClient client = new SmtpClient("smtp.yandex.ru", 587);
             client.EnableSsl = true;
             MailMessage mail = new MailMessage();
             mail.From = new MailAddress("testeren@yandex.com", "Şifre güncelleme");
             mail.To.Add(pPers.PersonelMail);
             mail.IsBodyHtml = true;
             mail.Subject = "Şifre yenileme isteği";
             var PersonelAdSoyad = pPers.PersonelAdi + " " + pPers.PersonelSoyadi;
             mail.Body += "Merhaba " + PersonelAdSoyad + "<br/> Şifreniz " + pPers.PersonelSifre;
             NetworkCredential net = new NetworkCredential("testerennediosunkiz@yandex.com", "eren123");
             client.Credentials = net;
             client.Send(mail);
             return RedirectToAction("Index");
            */

            
            pPers.PersonelDurum = true;
            pPers.PersonelSifre =  SifreOlusturma.Olustur(8);
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