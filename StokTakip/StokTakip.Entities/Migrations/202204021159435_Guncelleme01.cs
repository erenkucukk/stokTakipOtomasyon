namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblStokHareket", "UrunSatisFiyat", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.tblStokHareket", "UrunBirimFiyat", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.tblStokHareket", "HareketTipi", c => c.Boolean(nullable: false));
            DropColumn("dbo.tblUrun", "UrunToplamFiyat");
            DropColumn("dbo.tblUrun", "Stokİslem");
            DropColumn("dbo.tblUrun", "StokPersonel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUrun", "StokPersonel", c => c.Int(nullable: false));
            AddColumn("dbo.tblUrun", "Stokİslem", c => c.Int(nullable: false));
            AddColumn("dbo.tblUrun", "UrunToplamFiyat", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.tblStokHareket", "HareketTipi");
            DropColumn("dbo.tblStokHareket", "UrunBirimFiyat");
            DropColumn("dbo.tblStokHareket", "UrunSatisFiyat");
        }
    }
}
