using System;

namespace StokTakip.Entities.Model
{
    public class Uye
    {
        /// <summary>
        /// Üye bilgilerinin tutulduğu tablo yapısı
        /// </summary>

        public int UyeId { get; set; }
        public string UyeAdi { get; set; }
        public string UyeSoyadi { get; set; }
        public int UyeTelefon { get; set; }
        public string Cinsiyet { get; set; }
        public string UyeMail { get; set; }
        public string UyeSifre { get; set; }
        public int YetkiId { get; set; }
        public virtual Yetki Yetki { get; set; }
        public DateTime UyeDogumTarihi { get; set; }
        public string UyeResim { get; set; }
        public bool UyeDurum { get; set; }
    }
}
