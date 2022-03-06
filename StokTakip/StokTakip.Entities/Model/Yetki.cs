using System.Collections.Generic;

namespace StokTakip.Entities.Model
{
    public class Yetki
    {
        /// <summary>
        /// Yetki bilgilerinin tutulduğu tablo yapısı
        /// </summary>

        public int YetkiId { get; set; }
        public string YetkiAdi { get; set; }
        public string YetkiAciklama { get; set; }
        public bool YetkiDurum { get; set; }

        public ICollection<Uye> Uyes { get; set; }
    }
}
