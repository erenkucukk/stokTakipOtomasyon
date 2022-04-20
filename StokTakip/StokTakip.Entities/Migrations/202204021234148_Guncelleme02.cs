namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme02 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblStokHareket", "UrunBirimFiyat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblStokHareket", "UrunBirimFiyat", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
