using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Model
{


    public class Kategori
    {
        /// <summary>
        /// Kategori bilgilerinin tutulduğu tablo yapısı
        /// </summary>
       
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public bool KategoriDurum { get; set; }
        public string KategoriAciklama { get; set; }

        public virtual ICollection<AltKategori> AltKategoris { get; set; }
        public virtual ICollection<StokGirisCikis> StokGirisCikiss { get; set; }

    }
}
