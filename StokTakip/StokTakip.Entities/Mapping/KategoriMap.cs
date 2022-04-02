using StokTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Mapping
{
    public class KategoriMap: EntityTypeConfiguration<Kategori>
    {
        public KategoriMap()
        {
            this.ToTable("tblKategori");
            this.Property(p => p.KategoriId).HasColumnType("int");
            this.Property(p => p.KategoriId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.KategoriAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.KategoriAciklama).HasColumnType("varchar").HasMaxLength(500);
        }
    }
}
