using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StokTakip.Entities.Mapping
{
    public class UyeMap: EntityTypeConfiguration<Uye>
    {
        public UyeMap()
        {
            this.ToTable("tblUye");
            this.Property(p => p.UyeId).HasColumnType("int");
            this.Property(p => p.UyeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.UyeAdi).HasColumnType("varchar").HasMaxLength(50);
            this.Property(p => p.UyeSoyadi).HasColumnType("varchar").HasMaxLength(50);
            this.Property(p => p.UyeTelefon).HasColumnType("int");
            this.Property(p => p.UyeMail).HasColumnType("varchar").HasMaxLength(50);
            this.Property(p => p.UyeSifre).HasColumnType("varchar").HasMaxLength(50);
            this.Property(p => p.YetkiId).HasColumnType("int");
            this.Property(p => p.UyeDogumTarihi).HasColumnType("date");
            this.Property(p => p.UyeResim).HasColumnType("varchar").HasMaxLength(500);

            this.HasRequired(p => p.Yetki).WithMany(p => p.Uyes).HasForeignKey(p => p.YetkiId);
        }
    }
}
