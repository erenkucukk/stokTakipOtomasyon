namespace StokTakip.Entities.Model
{
    public class AltKategori
    {
        /// <summary>
        /// Alt Kategori bilgilerinin tutulduğu tablo yapısı
        /// </summary>
        
        public int AltKategoriId { get; set; }
        public string AltKategoriAdi { get; set; }
        public bool AltKategoriDurum { get; set; }
        public string AltKategoriAciklama { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
