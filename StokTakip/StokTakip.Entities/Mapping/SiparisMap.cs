using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class SiparisMap : EntityTypeConfiguration<Siparis>
    {
        public SiparisMap()
        {

            this.ToTable("tblSiparis");
            this.Property(p => p.SiparisId).HasColumnType("int");
            this.Property(p => p.SiparisId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.ToplamUrunAdet).HasColumnType("int");
            this.Property(p => p.ToplamFiyat).HasColumnType("money");
            this.Property(p => p.ToplamIskonto).HasColumnType("int");
            this.Property(p => p.PersonelNo).HasColumnType("int");
            this.Property(p => p.UyeNo).HasColumnType("int");
            this.Property(p => p.SepetNo).HasColumnType("int");
            this.Property(p => p.Tarih).HasColumnType("date");




        }
    }
}
