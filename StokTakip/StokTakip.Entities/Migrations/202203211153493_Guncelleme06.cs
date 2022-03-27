namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme06 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblPersonel", "Telefon", c => c.String(maxLength: 15, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblPersonel", "Telefon");
        }
    }
}
