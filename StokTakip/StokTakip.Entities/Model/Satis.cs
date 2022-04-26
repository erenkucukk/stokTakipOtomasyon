using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Model
{
    public class Satis
    {
        [Key]
        public int SatisId { get; set; }
        public int UrunNo { get; set; }
        public int SepetNo { get; set; }
        public int BarkodNo { get; set; }
        public int BirimFiyat { get; set; }
        public int Miktar { get; set; }
        public int ToplamFiyat { get; set; }
        public int Iskonto { get; set; }
        public int BirimNo { get; set; }
        public DateTime Tarih { get; set; }
        public bool SatisDurum { get; set; }

        public virtual Urun Urun { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Sepet Sepet { get; set; }
        public virtual Birim Birim { get; set; }


    }
}
