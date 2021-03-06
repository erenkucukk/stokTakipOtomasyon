using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    class SatisMap : EntityTypeConfiguration<Satis>
    {
        public SatisMap()
        {
            this.ToTable("tblSatis");
            this.Property(p => p.SatisId).HasColumnType("int");
            this.Property(p => p.SatisId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.SiparisNo).HasColumnType("int");
            this.Property(p => p.UrunNo).HasColumnType("int");
            this.Property(p => p.PersonelNo).HasColumnType("int");
            this.Property(p => p.SepetNo).HasColumnType("int");
            this.Property(p => p.BarkodNo).HasColumnType("int");
            this.Property(p => p.BirimFiyat).HasColumnType("money");
            this.Property(p => p.Miktar).HasColumnType("int");
            this.Property(p => p.ToplamFiyat).HasColumnType("money");
            this.Property(p => p.Iskonto).HasColumnType("money");
            this.Property(p => p.BirimNo).HasColumnType("int");
            this.Property(p => p.Tarih).HasColumnType("date");


            this.HasRequired(p => p.Personel).WithMany(p => p.Satiss).HasForeignKey(p => p.PersonelNo);
            this.HasRequired(p => p.Urun).WithMany(p => p.Satiss).HasForeignKey(p => p.UrunNo);
            //this.HasRequired(p => p.Siparis).WithMany(p => p.Satiss).HasForeignKey(p => p.SiparisNo);


        }
    }
}
