namespace StokTakip.Entities.Model
{
    public class Marka
    {
        /// <summary>
        /// Marka bilgilerinin tutulduğu tablo yapısı
        /// </summary>

        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
        public string MarkaAciklama { get; set; }
        public bool MarkaDurum { get; set; }
    }
}
