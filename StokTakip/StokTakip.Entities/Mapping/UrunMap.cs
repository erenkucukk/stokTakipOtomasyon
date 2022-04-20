using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class UrunMap: EntityTypeConfiguration<Urun>
    {
        public UrunMap()
        {
            this.ToTable("tblUrun");
            this.Property(p => p.UrunId).HasColumnType("int");
            this.Property(p => p.UrunId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.UrunAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.UrunSatisFiyat).HasColumnType("money");
            this.Property(p => p.UrunMiktar).HasColumnType("int");
            this.Property(p => p.UrunBirimId).HasColumnType("int");
            this.Property(p => p.UrunMarkaId).HasColumnType("int");
            this.Property(p => p.UrunAciklama).HasColumnType("varchar").HasMaxLength(100);

            this.HasRequired(p => p.Birim).WithMany(p => p.Uruns).HasForeignKey(p => p.UrunBirimId);
            this.HasRequired(p => p.Kategori).WithMany(p => p.Uruns).HasForeignKey(p => p.UrunKategoriId);
            this.HasRequired(p => p.Marka).WithMany(p => p.Uruns).HasForeignKey(p => p.UrunMarkaId);

        }
    }
}
