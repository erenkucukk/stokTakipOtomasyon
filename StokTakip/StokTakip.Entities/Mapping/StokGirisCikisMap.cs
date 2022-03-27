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
            this.Property(p => p.UrunFiyat).HasColumnType("money");
            this.Property(p => p.UrunMiktar).HasColumnType("int");

        }
    }
}


