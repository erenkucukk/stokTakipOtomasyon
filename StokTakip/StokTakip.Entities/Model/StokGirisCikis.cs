﻿using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities.Model
{
    public class StokGirisCikis
    {
        /// <summary>
        /// Stok Giriş Çıkış bilgilerinin tutulduğu tablo yapısı
        /// </summary>
        [Key]
        public int UrunStokKodu{ get; set; }
        public int UrunMiktar { get; set; }
        public int UrunBirimId { get; set; }
        public virtual Birim Birim { get; set; }
        public int UrunKategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public int UrunAlisFiyat { get; set; }
        public int UrunToplamFiyat { get; set; }
        public string UrunAciklama { get; set; }
        public int Stokİslem { get; set; }
        public int StokPersonel { get; set; }
    }
}
