namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblStokHareket", "UrunSonFiyat", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblStokHareket", "UrunSonFiyat");
        }
    }
}
