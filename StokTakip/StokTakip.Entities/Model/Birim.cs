using System.Collections.Generic;

namespace StokTakip.Entities.Model
{
    public class Birim
    {
        /// <summary>
        /// Birim bilgilerinin tutulduğu tablo yapısı
        /// </summary>

        public int BirimId { get; set; }
        public string BirimAdi { get; set; }
        public string BirimAciklama { get; set; }
        public bool BirimDurum { get; set; }
        public virtual ICollection<Urun> Uruns { get; set; }



    }
}
