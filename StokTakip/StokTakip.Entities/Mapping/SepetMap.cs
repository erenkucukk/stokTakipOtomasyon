using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class SepetMap : EntityTypeConfiguration<Sepet>
    {
        public SepetMap()
        {
            this.ToTable("tblSepet");
            this.Property(p => p.SepetId).HasColumnType("int");
            this.Property(p => p.SepetId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.UrunNo).HasColumnType("int");
            this.Property(p => p.PersonelNo).HasColumnType("int");
            this.Property(p => p.BirimFiyat).HasColumnType("money");
            this.Property(p => p.Miktar).HasColumnType("int");
            this.Property(p => p.ToplamFiyat).HasColumnType("money");
            this.Property(p => p.Tarih).HasColumnType("date");


            this.HasRequired(p => p.Personel).WithMany(p => p.Sepets).HasForeignKey(p => p.PersonelNo);
            this.HasRequired(p => p.Urun).WithMany(p => p.Sepets).HasForeignKey(p => p.UrunNo);


        }
    }
}
