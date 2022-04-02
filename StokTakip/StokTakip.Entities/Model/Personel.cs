using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Model
{
   public class Personel
    {
        public int PersonelId { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string PersonelMail { get; set; }
        public string PersonelKAdi { get; set; }
        public string PersonelSifre { get; set; }
        public string Telefon { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Fotograf { get; set; }
        public bool PersonelDurum { get; set; }
        public int YetkiId { get; set; }
        public virtual Yetki Yetki { get; set; }

        public virtual ICollection<StokHareket> StokHarekets { get; set; }

    }
}
