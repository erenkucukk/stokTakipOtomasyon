namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAltKategori",
                c => new
                    {
                        AltKategoriId = c.Int(nullable: false, identity: true),
                        AltKategoriAdi = c.String(maxLength: 100, unicode: false),
                        AltKategoriDurum = c.Boolean(nullable: false),
                        AltKategoriAciklama = c.String(maxLength: 500, unicode: false),
                        KategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AltKategoriId)
                .ForeignKey("dbo.tblKtegori", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.tblKtegori",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(maxLength: 100, unicode: false),
                        KategoriDurum = c.Boolean(nullable: false),
                        KategoriAciklama = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.tblStokGirisCikis",
                c => new
                    {
                        UrunStokKodu = c.Int(nullable: false, identity: true),
                        UrunMiktar = c.Int(nullable: false),
                        UrunBirimId = c.Int(nullable: false),
                        UrunKategoriId = c.Int(nullable: false),
                        UrunAlisFiyat = c.Decimal(nullable: false, storeType: "money"),
                        UrunToplamFiyat = c.Decimal(nullable: false, storeType: "money"),
                        UrunAciklama = c.String(maxLength: 100, unicode: false),
                        Stokİslem = c.Int(nullable: false),
                        StokPersonel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunStokKodu)
                .ForeignKey("dbo.tblBirim", t => t.UrunBirimId, cascadeDelete: true)
                .ForeignKey("dbo.tblKtegori", t => t.UrunKategoriId, cascadeDelete: true)
                .Index(t => t.UrunBirimId)
                .Index(t => t.UrunKategoriId);
            
            CreateTable(
                "dbo.tblBirim",
                c => new
                    {
                        BirimId = c.Int(nullable: false, identity: true),
                        BirimAdi = c.String(maxLength: 50, unicode: false),
                        BirimAciklama = c.String(maxLength: 500, unicode: false),
                        BirimDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BirimId);
            
            CreateTable(
                "dbo.tblKartBilgileri",
                c => new
                    {
                        KartId = c.Int(nullable: false, identity: true),
                        KartAdi = c.String(maxLength: 100, unicode: false),
                        KartNumara = c.String(maxLength: 16, fixedLength: true, unicode: false),
                        KartTarih = c.DateTime(nullable: false, storeType: "date"),
                        KartDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KartId);
            
            CreateTable(
                "dbo.tblKasa",
                c => new
                    {
                        KasaId = c.Int(nullable: false, identity: true),
                        KasaAciklama = c.String(maxLength: 500, unicode: false),
                        KasaDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KasaId);
            
            CreateTable(
                "dbo.tblKasaHareketleri",
                c => new
                    {
                        OdemeId = c.Int(nullable: false, identity: true),
                        OdemeSecenek = c.Int(nullable: false),
                        OdemeTarih = c.DateTime(nullable: false, storeType: "date"),
                        OdemeMiktar = c.Decimal(nullable: false, storeType: "money"),
                        OdemeDurum = c.Boolean(nullable: false),
                        KasaSecenek = c.Int(nullable: false),
                        KasaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OdemeId)
                .ForeignKey("dbo.tblKasa", t => t.KasaId, cascadeDelete: true)
                .Index(t => t.KasaId);
            
            CreateTable(
                "dbo.tblMarka",
                c => new
                    {
                        MarkaId = c.Int(nullable: false, identity: true),
                        MarkaAdi = c.String(maxLength: 50, unicode: false),
                        MarkaAciklama = c.String(maxLength: 50, unicode: false),
                        MarkaDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MarkaId);
            
            CreateTable(
                "dbo.tblUrun",
                c => new
                    {
                        UrunStokKodu = c.Int(nullable: false, identity: true),
                        UrunMiktar = c.Int(nullable: false),
                        UrunFiyat = c.Decimal(nullable: false, storeType: "money"),
                        KritikStokSeviyesi = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UrunStokKodu);
            
            CreateTable(
                "dbo.tblUye",
                c => new
                    {
                        UyeId = c.Int(nullable: false, identity: true),
                        UyeAdi = c.String(maxLength: 50, unicode: false),
                        UyeSoyadi = c.String(maxLength: 50, unicode: false),
                        UyeTelefon = c.Int(nullable: false),
                        UyeMail = c.String(maxLength: 50, unicode: false),
                        UyeSifre = c.String(maxLength: 50, unicode: false),
                        YetkiId = c.Int(nullable: false),
                        UyeDogumTarihi = c.DateTime(nullable: false, storeType: "date"),
                        UyeResim = c.String(maxLength: 500, unicode: false),
                        UyeDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UyeId)
                .ForeignKey("dbo.tblYetki", t => t.YetkiId, cascadeDelete: true)
                .Index(t => t.YetkiId);
            
            CreateTable(
                "dbo.tblYetki",
                c => new
                    {
                        YetkiId = c.Int(nullable: false, identity: true),
                        YetkiAdi = c.String(maxLength: 50, unicode: false),
                        YetkiAciklama = c.String(maxLength: 500, unicode: false),
                        YetkiDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YetkiId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUye", "YetkiId", "dbo.tblYetki");
            DropForeignKey("dbo.tblKasaHareketleri", "KasaId", "dbo.tblKasa");
            DropForeignKey("dbo.tblAltKategori", "KategoriId", "dbo.tblKtegori");
            DropForeignKey("dbo.tblStokGirisCikis", "UrunKategoriId", "dbo.tblKtegori");
            DropForeignKey("dbo.tblStokGirisCikis", "UrunBirimId", "dbo.tblBirim");
            DropIndex("dbo.tblUye", new[] { "YetkiId" });
            DropIndex("dbo.tblKasaHareketleri", new[] { "KasaId" });
            DropIndex("dbo.tblStokGirisCikis", new[] { "UrunKategoriId" });
            DropIndex("dbo.tblStokGirisCikis", new[] { "UrunBirimId" });
            DropIndex("dbo.tblAltKategori", new[] { "KategoriId" });
            DropTable("dbo.tblYetki");
            DropTable("dbo.tblUye");
            DropTable("dbo.tblUrun");
            DropTable("dbo.tblMarka");
            DropTable("dbo.tblKasaHareketleri");
            DropTable("dbo.tblKasa");
            DropTable("dbo.tblKartBilgileri");
            DropTable("dbo.tblBirim");
            DropTable("dbo.tblStokGirisCikis");
            DropTable("dbo.tblKtegori");
            DropTable("dbo.tblAltKategori");
        }
    }
}
