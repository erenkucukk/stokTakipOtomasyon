using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Model
{
    public class Sepet
    {
        [Key]
        public int SepetId { get; set; }
        public int PersonelNo { get; set; }
        public int UrunNo { get; set; }
        public int BirimFiyat { get; set; }
        public int Miktar { get; set; }
        public int ToplamFiyat { get; set; }
        public DateTime Tarih { get; set; }
        public bool SepetDurum { get; set; }

        public virtual Urun Urun { get; set; }
        public virtual Personel Personel { get; set; }

    }
}
