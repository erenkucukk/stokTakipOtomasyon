namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme05 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblUrun", "UrunBirimFiyat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUrun", "UrunBirimFiyat", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
