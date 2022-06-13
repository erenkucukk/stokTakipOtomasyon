using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace StokTakip.MVC.Models
{
    public static class SifreOlusturma
    {
        private readonly static Random rastgele = new Random();

        public static string Olustur(int uzunluk = 24)
        {
            const string kucuk_harf = "abcdefghijklmnopqrstuvwxyz";
            const string buyuk_harf = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numara = "1234567890";
            const string ozel_karakter = "!@#$%^&*_-=+";

            // Get cryptographically random sequence of bytes
            var bytes = new byte[uzunluk];
            new RNGCryptoServiceProvider().GetBytes(bytes);

            // Build up a string using random bytes and character classes
            var sonuc = new StringBuilder();
            foreach (byte b in bytes)
            {
                // Randomly select a character class for each byte
                switch (rastgele.Next(4))
                {
                    // In each case use mod to project byte b to the correct range
                    case 0:
                        sonuc.Append(kucuk_harf[b % kucuk_harf.Count()]);
                        break;
                    case 1:
                        sonuc.Append(buyuk_harf[b % buyuk_harf.Count()]);
                        break;
                    case 2:
                        sonuc.Append(numara[b % numara.Count()]);
                        break;
                    case 3:
                        sonuc.Append(ozel_karakter[b % ozel_karakter.Count()]);
                        break;
                }
            }
            return sonuc.ToString();
        }
    }

}