namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme04 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblUye", "YetkiId", "dbo.tblYetki");
            DropIndex("dbo.tblUye", new[] { "YetkiId" });
            CreateTable(
                "dbo.tblPersonel",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        PersonelAdi = c.String(maxLength: 50, unicode: false),
                        PersonelSoyadi = c.String(maxLength: 50, unicode: false),
                        PersonelMail = c.String(maxLength: 50, unicode: false),
                        PersonelKAdi = c.String(maxLength: 50, unicode: false),
                        PersonelSifre = c.String(maxLength: 50, unicode: false),
                        DogumTarihi = c.DateTime(nullable: false, storeType: "date"),
                        PersonelDurum = c.Boolean(nullable: false),
                        YetkiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.tblYetki", t => t.YetkiId, cascadeDelete: true)
                .Index(t => t.YetkiId);
            
            DropColumn("dbo.tblUye", "UyeSifre");
            DropColumn("dbo.tblUye", "YetkiId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUye", "YetkiId", c => c.Int(nullable: false));
            AddColumn("dbo.tblUye", "UyeSifre", c => c.String(maxLength: 50, unicode: false));
            DropForeignKey("dbo.tblPersonel", "YetkiId", "dbo.tblYetki");
            DropIndex("dbo.tblPersonel", new[] { "YetkiId" });
            DropTable("dbo.tblPersonel");
            CreateIndex("dbo.tblUye", "YetkiId");
            AddForeignKey("dbo.tblUye", "YetkiId", "dbo.tblYetki", "YetkiId", cascadeDelete: true);
        }
    }
}
