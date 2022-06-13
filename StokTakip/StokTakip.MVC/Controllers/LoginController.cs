using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StokTakip.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Personel pPersonel)
        {
            pPersonel.PersonelKAdi = pPersonel.PersonelMail;
            using (StokTakipContext db = new StokTakipContext())
            {
                Personel personel = db.Personels.AsNoTracking().Where(x => (x.PersonelMail == pPersonel.PersonelMail || x.PersonelKAdi == pPersonel.PersonelKAdi) && x.PersonelSifre == pPersonel.PersonelSifre).FirstOrDefault();



                if (personel != null)
                {
                    FormsAuthentication.SetAuthCookie(personel.PersonelKAdi, false);
                    // Sistem Login olundu.
                    Session["PersonelId"] = personel.PersonelId;
                    Session["Personeli"] = personel.PersonelAdi + " " + personel.PersonelSoyadi;
                    Session["PersonelMail"] = personel.PersonelMail;
                    Session["PersonelFotograf"] = personel.Fotograf;
                    Session["YetkiId"] = personel.YetkiId;
                    return RedirectToAction("Index", "Kategori");
                }
            }


            return RedirectToAction("Index");
        }

        public ActionResult CikisYap()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }

    
}