using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities.Model
{
    public class Urun
    {
        /// <summary>
        /// Ürün bilgilerinin tutulduğu tablo yapısı
        /// </summary>

        [Key]
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int UrunMiktar { get; set; }
        public int UrunBirimId { get; set; }
        public virtual Birim Birim { get; set; }
        public int UrunKategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public int UrunMarkaId { get; set; }
        public virtual Marka Marka { get; set; }
        public int UrunSatisFiyat { get; set; }
        public string UrunAciklama { get; set; }
        public bool UrunDurum { get; set; }

        public virtual ICollection<Sepet> Sepets { get; set; }
        public virtual ICollection<StokHareket> StokHarekets { get; set; }

    }
}
