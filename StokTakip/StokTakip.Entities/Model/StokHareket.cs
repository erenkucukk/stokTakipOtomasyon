using System;
using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities.Model
{
    public class StokHareket
    {
        /// <summary>
        /// Stok Giriş Çıkış bilgilerinin tutulduğu tablo yapısı
        /// </summary>
        
        [Key]
        public int HareketId { get; set; }
        public int UrunId { get; set; }
        public int PersonelId { get; set; }
        public int UrunMiktar { get; set; }
        public int UrunAlisFiyat { get; set; }
        public int UrunSatisFiyat { get; set; }
        public int UrunBirimFiyat { get; set; }
        public DateTime Tarih { get; set; }
        public bool Durum { get; set; }
        public bool HareketTipi { get; set; }
        public int StokPersonel { get; set; }

        public virtual Urun Urun { get; set; }
        public virtual Personel Personel { get; set; }


    }
}
