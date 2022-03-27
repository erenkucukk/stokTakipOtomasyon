namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Güncelleme02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblUye", "Cinsiyet", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUye", "Cinsiyet");
        }
    }
}
