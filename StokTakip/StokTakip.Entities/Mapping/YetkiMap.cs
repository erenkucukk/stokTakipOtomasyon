using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class YetkiMap: EntityTypeConfiguration<Yetki>
    {
        public YetkiMap()
        {
            this.ToTable("tblYetki");
            this.Property(p => p.YetkiId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.YetkiId).HasColumnType("int");
            this.Property(p => p.YetkiAdi).HasColumnType("varchar").HasMaxLength(50);
            this.Property(p => p.YetkiAciklama).HasColumnType("varchar").HasMaxLength(500);

        }
    }
}
