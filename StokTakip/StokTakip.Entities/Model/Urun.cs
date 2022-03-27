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
        public string UrunAdi { get; set; }
        public int UrunMiktar { get; set; }
        public int UrunBirimId { get; set; }
        public virtual Birim Birim { get; set; }
        public int UrunKategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public int UrunMarkaId { get; set; }
        public virtual Marka Marka { get; set; }
        public int UrunAlisFiyat { get; set; }
        public int UrunToplamFiyat { get; set; }
        public string UrunAciklama { get; set; }
        public int Stokİslem { get; set; }
        public int StokPersonel { get; set; }
        public bool UrunDurum { get; set; }

    }
}
