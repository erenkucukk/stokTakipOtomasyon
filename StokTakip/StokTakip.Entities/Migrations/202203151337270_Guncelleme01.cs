namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblStokGirisCikis", "UrunDurum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblStokGirisCikis", "UrunDurum");
        }
    }
}
