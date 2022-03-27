using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities.Model
{
    public class StokGirisCikis
    {
        /// <summary>
        /// Stok Giriş Çıkış bilgilerinin tutulduğu tablo yapısı
        /// </summary>
        [Key]

        public int UrunStokKodu { get; set; }
        public int UrunMiktar { get; set; }
        public int UrunFiyat { get; set; }

    }
}
