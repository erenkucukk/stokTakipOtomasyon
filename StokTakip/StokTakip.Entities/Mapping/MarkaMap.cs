using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class MarkaMap: EntityTypeConfiguration<Marka>
    {
        public MarkaMap()
        {
            this.ToTable("tblMarka");
            this.Property(p => p.MarkaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.MarkaId).HasColumnType("int");
            this.Property(p => p.MarkaAdi).HasColumnType("varchar").HasMaxLength(50);
            this.Property(p => p.MarkaAciklama).HasColumnType("varchar").HasMaxLength(50);



        }
    }
}
