namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class son : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblUrun", "UrunAltKategoriId", "dbo.tblAltKategori");
            DropIndex("dbo.tblUrun", new[] { "UrunAltKategoriId" });
            CreateIndex("dbo.tblUrun", "UrunKategoriId");
            AddForeignKey("dbo.tblUrun", "UrunKategoriId", "dbo.tblKategori", "KategoriId", cascadeDelete: true);
            DropColumn("dbo.tblUrun", "UrunAltKategoriId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUrun", "UrunAltKategoriId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tblUrun", "UrunKategoriId", "dbo.tblKategori");
            DropIndex("dbo.tblUrun", new[] { "UrunKategoriId" });
            CreateIndex("dbo.tblUrun", "UrunAltKategoriId");
            AddForeignKey("dbo.tblUrun", "UrunAltKategoriId", "dbo.tblAltKategori", "AltKategoriId", cascadeDelete: true);
        }
    }
}
