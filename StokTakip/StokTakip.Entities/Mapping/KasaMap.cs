using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class KasaMap: EntityTypeConfiguration<Kasa>
    {
        public KasaMap()
        {
            this.ToTable("tblKasa");
            this.Property(p => p.KasaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.KasaId).HasColumnType("int");
            this.Property(p => p.KasaAciklama).HasColumnType("varchar").HasMaxLength(500);


        }
    }
}
