using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class KasaHareketleriMap: EntityTypeConfiguration<KasaHareketleri>
    {
        public KasaHareketleriMap()
        {
            this.ToTable("tblKasaHareketleri");
            this.Property(p => p.OdemeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.OdemeId).HasColumnType("int");
            this.Property(p => p.OdemeSecenek).HasColumnType("int");
            this.Property(p => p.OdemeTarih).HasColumnType("date");
            this.Property(p => p.OdemeMiktar).HasColumnType("money");
            this.Property(p => p.KasaSecenek).HasColumnType("int");
            this.Property(p => p.KasaId).HasColumnType("int");

            this.HasRequired(p => p.Kasa).WithMany(p => p.KasaHareketleris).HasForeignKey(p => p.KasaId);

        }
    }
}
