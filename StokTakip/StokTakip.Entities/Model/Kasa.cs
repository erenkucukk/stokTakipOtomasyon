using System.Collections.Generic;

namespace StokTakip.Entities.Model
{
    public class Kasa
    {
        /// <summary>
        /// Kasa bilgilerinin tutulduğu tablo yapısı
        /// </summary>

        public int KasaId { get; set; }
        public string KasaAciklama { get; set; }
        public bool KasaDurum { get; set; }

        public ICollection<KasaHareketleri> KasaHareketleris { get; set; }
    }
}
