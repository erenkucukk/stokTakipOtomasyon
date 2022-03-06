using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class StokGirisCikisMap: EntityTypeConfiguration<StokGirisCikis>
    {
        public StokGirisCikisMap()
        {
            this.ToTable("tblStokGirisCikis");
            this.Property(p => p.UrunStokKodu).HasColumnType("int");
            this.Property(p => p.UrunStokKodu).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.UrunAlisFiyat).HasColumnType("money");
            this.Property(p => p.UrunToplamFiyat).HasColumnType("money");
            this.Property(p => p.UrunMiktar).HasColumnType("int");
            this.Property(p => p.UrunBirimId).HasColumnType("int");
            this.Property(p => p.UrunAciklama).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.Stokİslem).HasColumnType("int");
            this.Property(p => p.StokPersonel).HasColumnType("int");

            this.HasRequired(p => p.Birim).WithMany(p => p.StokGirisCikiss).HasForeignKey(p => p.UrunBirimId);
            this.HasRequired(p => p.Kategori).WithMany(p => p.StokGirisCikiss).HasForeignKey(p => p.UrunKategoriId);
            

        }
    }
}
