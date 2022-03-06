using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class AltKategoriMap: EntityTypeConfiguration<AltKategori> 
    {
        public AltKategoriMap()
        {
            this.ToTable("tblAltKategori");
            this.Property(p => p.AltKategoriId).HasColumnType("int");
            this.Property(p => p.AltKategoriId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.AltKategoriAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.AltKategoriAciklama).HasColumnType("varchar").HasMaxLength(500);

            this.HasRequired(p => p.Kategori).WithMany(p => p.AltKategoris).HasForeignKey(p => p.KategoriId);

        }
    }
}
