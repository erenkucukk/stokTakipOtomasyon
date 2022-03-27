using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities.Model
{
    public class Marka
    {
        /// <summary>
        /// Marka bilgilerinin tutulduğu tablo yapısı
        /// </summary>

        [Key]
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
        public string MarkaAciklama { get; set; }
        public bool MarkaDurum { get; set; }

        public virtual ICollection<Urun> Uruns { get; set; }

    }
}
