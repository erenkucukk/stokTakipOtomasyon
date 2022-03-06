using System;
using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities.Model
{
    public class KasaHareketleri
    {
        /// <summary>
        /// Kasa Hareketleri bilgilerinin tutulduğu tablo yapısı
        /// </summary>
        [Key]
        public int OdemeId { get; set; }
        public int OdemeSecenek { get; set; }
        public DateTime OdemeTarih { get; set; }
        public int OdemeMiktar { get; set; }
        public bool OdemeDurum { get; set; }
        public int KasaSecenek { get; set; }
        public int KasaId { get; set; }

        public virtual Kasa Kasa { get; set; }
    }
}
