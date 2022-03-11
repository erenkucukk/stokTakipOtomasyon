using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.MVC.Controllers
{
    public class MarkaController : Controller
    {
        StokTakipContext db = new StokTakipContext(); 

        // GET: Marka
        public ActionResult Index()
        {
            List<Marka> markalar = db.Markas.Where(x => x.MarkaDurum == true).ToList();
            return View(markalar);
        }
    }
}