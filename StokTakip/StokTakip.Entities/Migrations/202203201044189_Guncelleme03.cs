namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblStokGirisCikis", "UrunBirimId", "dbo.tblBirim");
            DropForeignKey("dbo.tblStokGirisCikis", "UrunKategoriId", "dbo.tblKtegori");
            DropIndex("dbo.tblStokGirisCikis", new[] { "UrunBirimId" });
            DropIndex("dbo.tblStokGirisCikis", new[] { "UrunKategoriId" });
            AddColumn("dbo.tblStokGirisCikis", "UrunFiyat", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.tblUrun", "UrunAdi", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tblUrun", "UrunBirimId", c => c.Int(nullable: false));
            AddColumn("dbo.tblUrun", "UrunKategoriId", c => c.Int(nullable: false));
            AddColumn("dbo.tblUrun", "UrunMarkaId", c => c.Int(nullable: false));
            AddColumn("dbo.tblUrun", "UrunAlisFiyat", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.tblUrun", "UrunToplamFiyat", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.tblUrun", "UrunAciklama", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tblUrun", "Stokİslem", c => c.Int(nullable: false));
            AddColumn("dbo.tblUrun", "StokPersonel", c => c.Int(nullable: false));
            AddColumn("dbo.tblUrun", "UrunDurum", c => c.Boolean(nullable: false));
            CreateIndex("dbo.tblUrun", "UrunBirimId");
            CreateIndex("dbo.tblUrun", "UrunKategoriId");
            CreateIndex("dbo.tblUrun", "UrunMarkaId");
            AddForeignKey("dbo.tblUrun", "UrunBirimId", "dbo.tblBirim", "BirimId", cascadeDelete: true);
            AddForeignKey("dbo.tblUrun", "UrunKategoriId", "dbo.tblKtegori", "KategoriId", cascadeDelete: true);
            AddForeignKey("dbo.tblUrun", "UrunMarkaId", "dbo.tblMarka", "MarkaId", cascadeDelete: true);
            DropColumn("dbo.tblStokGirisCikis", "UrunBirimId");
            DropColumn("dbo.tblStokGirisCikis", "UrunKategoriId");
            DropColumn("dbo.tblStokGirisCikis", "UrunAlisFiyat");
            DropColumn("dbo.tblStokGirisCikis", "UrunToplamFiyat");
            DropColumn("dbo.tblStokGirisCikis", "UrunAciklama");
            DropColumn("dbo.tblStokGirisCikis", "Stokİslem");
            DropColumn("dbo.tblStokGirisCikis", "StokPersonel");
            DropColumn("dbo.tblStokGirisCikis", "UrunDurum");
            DropColumn("dbo.tblUrun", "UrunFiyat");
            DropColumn("dbo.tblUrun", "KritikStokSeviyesi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUrun", "KritikStokSeviyesi", c => c.Double(nullable: false));
            AddColumn("dbo.tblUrun", "UrunFiyat", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.tblStokGirisCikis", "UrunDurum", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblStokGirisCikis", "StokPersonel", c => c.Int(nullable: false));
            AddColumn("dbo.tblStokGirisCikis", "Stokİslem", c => c.Int(nullable: false));
            AddColumn("dbo.tblStokGirisCikis", "UrunAciklama", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tblStokGirisCikis", "UrunToplamFiyat", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.tblStokGirisCikis", "UrunAlisFiyat", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.tblStokGirisCikis", "UrunKategoriId", c => c.Int(nullable: false));
            AddColumn("dbo.tblStokGirisCikis", "UrunBirimId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tblUrun", "UrunMarkaId", "dbo.tblMarka");
            DropForeignKey("dbo.tblUrun", "UrunKategoriId", "dbo.tblKtegori");
            DropForeignKey("dbo.tblUrun", "UrunBirimId", "dbo.tblBirim");
            DropIndex("dbo.tblUrun", new[] { "UrunMarkaId" });
            DropIndex("dbo.tblUrun", new[] { "UrunKategoriId" });
            DropIndex("dbo.tblUrun", new[] { "UrunBirimId" });
            DropColumn("dbo.tblUrun", "UrunDurum");
            DropColumn("dbo.tblUrun", "StokPersonel");
            DropColumn("dbo.tblUrun", "Stokİslem");
            DropColumn("dbo.tblUrun", "UrunAciklama");
            DropColumn("dbo.tblUrun", "UrunToplamFiyat");
            DropColumn("dbo.tblUrun", "UrunAlisFiyat");
            DropColumn("dbo.tblUrun", "UrunMarkaId");
            DropColumn("dbo.tblUrun", "UrunKategoriId");
            DropColumn("dbo.tblUrun", "UrunBirimId");
            DropColumn("dbo.tblUrun", "UrunAdi");
            DropColumn("dbo.tblStokGirisCikis", "UrunFiyat");
            CreateIndex("dbo.tblStokGirisCikis", "UrunKategoriId");
            CreateIndex("dbo.tblStokGirisCikis", "UrunBirimId");
            AddForeignKey("dbo.tblStokGirisCikis", "UrunKategoriId", "dbo.tblKtegori", "KategoriId", cascadeDelete: true);
            AddForeignKey("dbo.tblStokGirisCikis", "UrunBirimId", "dbo.tblBirim", "BirimId", cascadeDelete: true);
        }
    }
}
