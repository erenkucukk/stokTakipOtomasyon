namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guncelleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblPersonel", "PersonelYeni", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblPersonel", "PersonelYeni");
        }
    }
}
