using StokTakip.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace StokTakip.Entities.Mapping
{
    class PersonelMap: EntityTypeConfiguration<Personel>
        {
            public PersonelMap()
            {
                this.ToTable("tblPersonel");
                this.Property(p => p.PersonelId).HasColumnType("int");
                this.Property(p => p.PersonelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                this.Property(p => p.PersonelAdi).HasColumnType("varchar").HasMaxLength(50);
                this.Property(p => p.PersonelSoyadi).HasColumnType("varchar").HasMaxLength(50);
                this.Property(p => p.PersonelMail).HasColumnType("varchar").HasMaxLength(50);
                this.Property(p => p.PersonelKAdi).HasColumnType("varchar").HasMaxLength(50);
                this.Property(p => p.PersonelSifre).HasColumnType("varchar").HasMaxLength(50);
                this.Property(p => p.Telefon).HasColumnType("varchar").HasMaxLength(15);
                this.Property(p => p.DogumTarihi).HasColumnType("date");
                this.Property(p => p.Fotograf).HasColumnType("varchar").HasMaxLength(200);

                this.HasRequired(p => p.Yetki).WithMany(p => p.Personels).HasForeignKey(p => p.YetkiId);
            }
        }
    }

