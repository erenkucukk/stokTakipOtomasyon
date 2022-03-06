using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class KartBilgileriMap: EntityTypeConfiguration<KartBilgileri>
    {
        public KartBilgileriMap()
        {
            this.ToTable("tblKartBilgileri");
            this.Property(p => p.KartId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.KartId).HasColumnType("int");
            this.Property(p => p.KartAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.KartNumara).HasColumnType("char").HasMaxLength(16);
            this.Property(p => p.KartTarih).HasColumnType("date");

        }
    }
}
