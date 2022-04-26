﻿namespace StokTakip.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseSonHal : DbMigration
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
                .ForeignKey("dbo.tblKategori", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.tblKategori",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(maxLength: 100, unicode: false),
                        KategoriDurum = c.Boolean(nullable: false),
                        KategoriAciklama = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.tblUrun",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAdi = c.String(maxLength: 100, unicode: false),
                        UrunMiktar = c.Int(nullable: false),
                        UrunBirimId = c.Int(nullable: false),
                        UrunKategoriId = c.Int(nullable: false),
                        UrunMarkaId = c.Int(nullable: false),
                        UrunSatisFiyat = c.Decimal(nullable: false, storeType: "money"),
                        UrunAciklama = c.String(maxLength: 100, unicode: false),
                        UrunDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.tblBirim", t => t.UrunBirimId, cascadeDelete: true)
                .ForeignKey("dbo.tblKategori", t => t.UrunKategoriId, cascadeDelete: true)
                .ForeignKey("dbo.tblMarka", t => t.UrunMarkaId, cascadeDelete: true)
                .Index(t => t.UrunBirimId)
                .Index(t => t.UrunKategoriId)
                .Index(t => t.UrunMarkaId);
            
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
                "dbo.tblSepet",
                c => new
                    {
                        SepetId = c.Int(nullable: false, identity: true),
                        PersonelNo = c.Int(nullable: false),
                        UrunNo = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, storeType: "money"),
                        Miktar = c.Int(nullable: false),
                        ToplamFiyat = c.Decimal(nullable: false, storeType: "money"),
                        Tarih = c.DateTime(nullable: false, storeType: "date"),
                        SepetDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SepetId)
                .ForeignKey("dbo.tblPersonel", t => t.PersonelNo, cascadeDelete: true)
                .ForeignKey("dbo.tblUrun", t => t.UrunNo, cascadeDelete: true)
                .Index(t => t.PersonelNo)
                .Index(t => t.UrunNo);
            
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
                        Telefon = c.String(maxLength: 15, unicode: false),
                        DogumTarihi = c.DateTime(nullable: false, storeType: "date"),
                        Fotograf = c.String(maxLength: 200, unicode: false),
                        PersonelDurum = c.Boolean(nullable: false),
                        YetkiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.tblYetki", t => t.YetkiId, cascadeDelete: true)
                .Index(t => t.YetkiId);
            
            CreateTable(
                "dbo.tblStokHareket",
                c => new
                    {
                        HareketId = c.Int(nullable: false, identity: true),
                        UrunId = c.Int(nullable: false),
                        PersonelId = c.Int(nullable: false),
                        UrunMiktar = c.Int(nullable: false),
                        UrunAlisFiyat = c.Decimal(nullable: false, storeType: "money"),
                        UrunSatisFiyat = c.Decimal(nullable: false, storeType: "money"),
                        UrunSonFiyat = c.Single(nullable: false),
                        Iskonto = c.Double(nullable: false),
                        Tarih = c.DateTime(nullable: false, storeType: "date"),
                        Durum = c.Boolean(nullable: false),
                        HareketTipi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HareketId)
                .ForeignKey("dbo.tblPersonel", t => t.PersonelId, cascadeDelete: true)
                .ForeignKey("dbo.tblUrun", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId)
                .Index(t => t.PersonelId);
            
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
            
            CreateTable(
                "dbo.tblSatis",
                c => new
                    {
                        SatisId = c.Int(nullable: false, identity: true),
                        UrunNo = c.Int(nullable: false),
                        SepetNo = c.Int(nullable: false),
                        BarkodNo = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, storeType: "money"),
                        Miktar = c.Int(nullable: false),
                        ToplamFiyat = c.Decimal(nullable: false, storeType: "money"),
                        Iskonto = c.Decimal(nullable: false, storeType: "money"),
                        BirimNo = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false, storeType: "date"),
                        SatisDurum = c.Boolean(nullable: false),
                        Birim_BirimId = c.Int(),
                        Personel_PersonelId = c.Int(),
                        Urun_UrunId = c.Int(),
                    })
                .PrimaryKey(t => t.SatisId)
                .ForeignKey("dbo.tblBirim", t => t.Birim_BirimId)
                .ForeignKey("dbo.tblPersonel", t => t.Personel_PersonelId)
                .ForeignKey("dbo.tblSepet", t => t.SepetNo, cascadeDelete: true)
                .ForeignKey("dbo.tblUrun", t => t.Urun_UrunId)
                .Index(t => t.SepetNo)
                .Index(t => t.Birim_BirimId)
                .Index(t => t.Personel_PersonelId)
                .Index(t => t.Urun_UrunId);
            
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
                "dbo.tblKasa",
                c => new
                    {
                        KasaId = c.Int(nullable: false, identity: true),
                        KasaAciklama = c.String(maxLength: 500, unicode: false),
                        KasaDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KasaId);
            
            CreateTable(
                "dbo.tblUye",
                c => new
                    {
                        UyeId = c.Int(nullable: false, identity: true),
                        UyeAdi = c.String(maxLength: 50, unicode: false),
                        UyeSoyadi = c.String(maxLength: 50, unicode: false),
                        UyeTelefon = c.Int(nullable: false),
                        Cinsiyet = c.String(),
                        UyeMail = c.String(maxLength: 50, unicode: false),
                        UyeDogumTarihi = c.DateTime(nullable: false, storeType: "date"),
                        UyeResim = c.String(maxLength: 500, unicode: false),
                        UyeDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UyeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblKasaHareketleri", "KasaId", "dbo.tblKasa");
            DropForeignKey("dbo.tblAltKategori", "KategoriId", "dbo.tblKategori");
            DropForeignKey("dbo.tblSepet", "UrunNo", "dbo.tblUrun");
            DropForeignKey("dbo.tblSatis", "Urun_UrunId", "dbo.tblUrun");
            DropForeignKey("dbo.tblSatis", "SepetNo", "dbo.tblSepet");
            DropForeignKey("dbo.tblSatis", "Personel_PersonelId", "dbo.tblPersonel");
            DropForeignKey("dbo.tblSatis", "Birim_BirimId", "dbo.tblBirim");
            DropForeignKey("dbo.tblSepet", "PersonelNo", "dbo.tblPersonel");
            DropForeignKey("dbo.tblPersonel", "YetkiId", "dbo.tblYetki");
            DropForeignKey("dbo.tblStokHareket", "UrunId", "dbo.tblUrun");
            DropForeignKey("dbo.tblStokHareket", "PersonelId", "dbo.tblPersonel");
            DropForeignKey("dbo.tblUrun", "UrunMarkaId", "dbo.tblMarka");
            DropForeignKey("dbo.tblUrun", "UrunKategoriId", "dbo.tblKategori");
            DropForeignKey("dbo.tblUrun", "UrunBirimId", "dbo.tblBirim");
            DropIndex("dbo.tblKasaHareketleri", new[] { "KasaId" });
            DropIndex("dbo.tblSatis", new[] { "Urun_UrunId" });
            DropIndex("dbo.tblSatis", new[] { "Personel_PersonelId" });
            DropIndex("dbo.tblSatis", new[] { "Birim_BirimId" });
            DropIndex("dbo.tblSatis", new[] { "SepetNo" });
            DropIndex("dbo.tblStokHareket", new[] { "PersonelId" });
            DropIndex("dbo.tblStokHareket", new[] { "UrunId" });
            DropIndex("dbo.tblPersonel", new[] { "YetkiId" });
            DropIndex("dbo.tblSepet", new[] { "UrunNo" });
            DropIndex("dbo.tblSepet", new[] { "PersonelNo" });
            DropIndex("dbo.tblUrun", new[] { "UrunMarkaId" });
            DropIndex("dbo.tblUrun", new[] { "UrunKategoriId" });
            DropIndex("dbo.tblUrun", new[] { "UrunBirimId" });
            DropIndex("dbo.tblAltKategori", new[] { "KategoriId" });
            DropTable("dbo.tblUye");
            DropTable("dbo.tblKasa");
            DropTable("dbo.tblKasaHareketleri");
            DropTable("dbo.tblKartBilgileri");
            DropTable("dbo.tblSatis");
            DropTable("dbo.tblYetki");
            DropTable("dbo.tblStokHareket");
            DropTable("dbo.tblPersonel");
            DropTable("dbo.tblSepet");
            DropTable("dbo.tblMarka");
            DropTable("dbo.tblBirim");
            DropTable("dbo.tblUrun");
            DropTable("dbo.tblKategori");
            DropTable("dbo.tblAltKategori");
        }
    }
}