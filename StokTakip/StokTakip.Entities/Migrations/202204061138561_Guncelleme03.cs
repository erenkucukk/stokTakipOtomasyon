namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblStokHareket", "Iskonto", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblStokHareket", "Iskonto");
        }
    }
}
