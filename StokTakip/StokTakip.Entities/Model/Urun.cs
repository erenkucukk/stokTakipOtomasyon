using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities.Model
{
    public class Urun
    {
        /// <summary>
        /// Ürün bilgilerinin tutulduğu tablo yapısı
        /// </summary>

        [Key]
        public int UrunStokKodu { get; set; }
        public int UrunMiktar { get; set; }
        public int UrunFiyat { get; set; }
        public int KritikStokSeviyesi { get; set; }
    }
}
