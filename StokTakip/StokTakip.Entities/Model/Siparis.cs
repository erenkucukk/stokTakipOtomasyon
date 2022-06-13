using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Model
{
    public class Siparis
    {
        [Key]
        public int SiparisId { get; set; }
        public int ToplamUrunAdet { get; set; }
        public int ToplamFiyat { get; set; }
        public int ToplamIskonto { get; set; }
        public DateTime Tarih { get; set; }
        public int PersonelNo { get; set; }
        public int UyeNo { get; set; }
        public int SepetNo { get; set; }


        //public virtual ICollection<Satis> Satiss { get; set; }
        //public virtual ICollection<Sepet> Sepets { get; set; }
    }
}
