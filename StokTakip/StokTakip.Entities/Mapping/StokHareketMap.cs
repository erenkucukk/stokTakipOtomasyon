using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class StokHareketMap: EntityTypeConfiguration<StokHareket>
    {
        public StokHareketMap()
        {
            this.ToTable("tblStokHareket");
            this.Property(p => p.HareketId).HasColumnType("int");
            this.Property(p => p.HareketId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.UrunId).HasColumnType("int");
            this.Property(p => p.PersonelId).HasColumnType("int");
            this.Property(p => p.UrunAlisFiyat).HasColumnType("money");
            this.Property(p => p.UrunSatisFiyat).HasColumnType("money");
            this.Property(p => p.Iskonto).HasColumnType("float");
            this.Property(p => p.UrunMiktar).HasColumnType("int");
            this.Property(p => p.Tarih).HasColumnType("datetime");

            this.HasRequired(p => p.Personel).WithMany(p => p.StokHarekets).HasForeignKey(p => p.PersonelId);
            this.HasRequired(p => p.Urun).WithMany(p => p.StokHarekets).HasForeignKey(p => p.UrunId);

        }
    }
}


