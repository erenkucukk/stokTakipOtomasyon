

using StokTakip.Entities.Mapping;
using System.Data.Entity;

namespace StokTakip.Entities.Model
{
    public class StokTakipContext : DbContext
    {
        public StokTakipContext() : base("name=StokTakipEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new AltKategoriMap());
            modelBuilder.Configurations.Add(new BirimMap());
            modelBuilder.Configurations.Add(new PersonelMap());
            modelBuilder.Configurations.Add(new KartBilgileriMap());
            modelBuilder.Configurations.Add(new KasaHareketleriMap());
            modelBuilder.Configurations.Add(new KasaMap());
            modelBuilder.Configurations.Add(new MarkaMap());
            modelBuilder.Configurations.Add(new StokHareketMap());
            modelBuilder.Configurations.Add(new UrunMap());
            modelBuilder.Configurations.Add(new UyeMap());
            modelBuilder.Configurations.Add(new YetkiMap());
        }

        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<AltKategori> AltKategoris { get; set; }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<KartBilgileri> KartBilgileris { get; set; }
        public DbSet<Kasa> Kasas { get; set; }
        public DbSet<KasaHareketleri> KasaHareketleris { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<StokHareket> StokHarekets { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Uye> Uyes { get; set; }
        public DbSet<Yetki> Yetkis { get; set; }
    }
}
