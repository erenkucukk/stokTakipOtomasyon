namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblPersonel", "Fotograf", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblPersonel", "Fotograf");
        }
    }
}
