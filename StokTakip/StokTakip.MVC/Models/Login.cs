using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StokTakip.MVC.Models
{
    public static class Login
    {
        //fields
        private static List<Kategori> kategoris;
        private static List<Personel> personels;
       // private static List<Urun> uruns;

        //properties
        public static List<Kategori> Kategoris
        {
            get {
                if (kategoris == null)
                {
                    KategorileriListele();
                }
                return kategoris; }
            set { kategoris = value; }
        }
        public static List<Personel> Personels
        {
            get
            {
                if (personels == null)
                {
                    PersonelleriListele();
                }
                return personels;
            }
            set { personels = value; }
        }
       /* public static List<Urun> Uruns
        {
            get
            {
                if (uruns == null)
                {
                    UrunleriListele();
                }
                return uruns;
            }
            set { uruns = value; }
        }*/


        private static void KategorileriListele()
        {
            using (StokTakipContext db = new StokTakipContext())
            {
                kategoris = db.Kategoris.AsNoTracking().ToList();
            }
        }

        private static void PersonelleriListele()
        {
            using (StokTakipContext db = new StokTakipContext())
            {
                personels = db.Personels.AsNoTracking().ToList();
            }
        }
       /* private static void UrunleriListele()
        {
            using (StokTakipContext db = new StokTakipContext())
            {
                uruns = db.Uruns.AsNoTracking().ToList();
            }
        }*/
    }
}