using System;
using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities.Model
{
    public class KartBilgileri
    {
        /// <summary>
        /// Kart bilgilerinin tutulduğu tablo yapısı
        /// </summary>

        [Key]
        public int KartId { get; set; }
        public string KartAdi { get; set; }
        public string KartNumara { get; set; }
        public DateTime KartTarih { get; set; }
        public bool KartDurum { get; set; }
    }
}
