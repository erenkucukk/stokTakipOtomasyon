using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class BirimMap: EntityTypeConfiguration<Birim>
    {
        public BirimMap()
        {
            this.ToTable("tblBirim");
            this.Property(p => p.BirimId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.BirimId).HasColumnType("int");
            this.Property(p => p.BirimAdi).HasColumnType("varchar").HasMaxLength(50);
            this.Property(p => p.BirimAciklama).HasColumnType("varchar").HasMaxLength(500);


        }
    }
}
