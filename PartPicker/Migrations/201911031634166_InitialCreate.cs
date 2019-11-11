namespace PartPicker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Build",
                c => new
                    {
                        BuildId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        CpuId = c.Int(nullable: false),
                        MoboId = c.Int(nullable: false),
                        GpuId = c.Int(nullable: false),
                        RamId = c.Int(nullable: false),
                        StorageId = c.Int(nullable: false),
                        PsuId = c.Int(nullable: false),
                        CaseId = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 45),
                        Hidden = c.Boolean(nullable: false),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.BuildId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Case", t => t.CaseId)
                .ForeignKey("dbo.Mobo", t => t.MoboId)
                .ForeignKey("dbo.Cpu", t => t.CpuId)
                .ForeignKey("dbo.Gpu", t => t.GpuId)
                .ForeignKey("dbo.Psu", t => t.PsuId)
                .ForeignKey("dbo.Ram", t => t.RamId)
                .ForeignKey("dbo.Storage", t => t.StorageId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CpuId)
                .Index(t => t.MoboId)
                .Index(t => t.GpuId)
                .Index(t => t.RamId)
                .Index(t => t.StorageId)
                .Index(t => t.PsuId)
                .Index(t => t.CaseId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Permission = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        BuildId = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.RateId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Build", t => t.BuildId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.BuildId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Case",
                c => new
                    {
                        CaseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        ManufacturerId = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 45),
                        Link = c.String(nullable: false, maxLength: 150),
                        FormFactorId = c.Int(nullable: false),
                        MaxFan = c.Int(nullable: false),
                        GpuLenght = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 45),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CaseId)
                .ForeignKey("dbo.FormFactor", t => t.FormFactorId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.FormFactorId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.FormFactor",
                c => new
                    {
                        FormFactorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.FormFactorId);
            
            CreateTable(
                "dbo.Mobo",
                c => new
                    {
                        MoboId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        ManufacturerId = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 45),
                        Link = c.String(nullable: false, maxLength: 150),
                        FormFactorId = c.Int(nullable: false),
                        SocketId = c.Int(nullable: false),
                        RamSlots = c.Int(nullable: false),
                        RamTypeId = c.Int(nullable: false),
                        MaxRam = c.Int(nullable: false),
                        SataSlots = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 45),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoboId)
                .ForeignKey("dbo.FormFactor", t => t.FormFactorId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .ForeignKey("dbo.RamType", t => t.RamTypeId)
                .ForeignKey("dbo.Socket", t => t.SocketId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.FormFactorId)
                .Index(t => t.SocketId)
                .Index(t => t.RamTypeId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        Image = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ManufacturerId = c.Int(nullable: false),
                        SeriesId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .ForeignKey("dbo.Series", t => t.SeriesId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.SeriesId);
            
            CreateTable(
                "dbo.Cpu",
                c => new
                    {
                        CpuId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        ProductId = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 45),
                        Link = c.String(nullable: false, maxLength: 150),
                        SocketId = c.Int(nullable: false),
                        Cores = c.Int(nullable: false),
                        Frequency = c.Double(nullable: false),
                        Turbo = c.Double(nullable: false),
                        Gpu = c.String(nullable: false, maxLength: 45),
                        Benchmark = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 45),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CpuId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .ForeignKey("dbo.Socket", t => t.SocketId)
                .Index(t => t.ProductId)
                .Index(t => t.SocketId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Shop",
                c => new
                    {
                        ShopId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        Logo = c.String(nullable: false, maxLength: 150),
                        Class = c.String(nullable: false, maxLength: 45),
                    })
                .PrimaryKey(t => t.ShopId);
            
            CreateTable(
                "dbo.Gpu",
                c => new
                    {
                        GpuId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        ProductId = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 45),
                        Link = c.String(nullable: false, maxLength: 150),
                        Ram = c.Int(nullable: false),
                        GpuRamId = c.Int(nullable: false),
                        Frequency = c.Double(nullable: false),
                        FrequencyBoost = c.Double(nullable: false),
                        Length = c.Int(nullable: false),
                        Benchmark = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 45),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GpuId)
                .ForeignKey("dbo.GpuRam", t => t.GpuRamId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .Index(t => t.ProductId)
                .Index(t => t.GpuRamId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.GpuRam",
                c => new
                    {
                        GpuRamId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GpuRamId);
            
            CreateTable(
                "dbo.Psu",
                c => new
                    {
                        PsuId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        ManufacturerId = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 45),
                        Link = c.String(nullable: false, maxLength: 150),
                        FormFactorId = c.Int(nullable: false),
                        Power = c.Int(nullable: false),
                        Efficiency = c.String(nullable: false, maxLength: 45),
                        Image = c.String(nullable: false, maxLength: 45),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PsuId)
                .ForeignKey("dbo.FormFactor", t => t.FormFactorId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.FormFactorId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Ram",
                c => new
                    {
                        RamId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        ManufacturerId = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 45),
                        Link = c.String(nullable: false, maxLength: 150),
                        RamTypeId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        Frequency = c.Int(nullable: false),
                        Cl = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 45),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RamId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .ForeignKey("dbo.RamType", t => t.RamTypeId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.RamTypeId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.RamType",
                c => new
                    {
                        RamTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.RamTypeId);
            
            CreateTable(
                "dbo.Storage",
                c => new
                    {
                        StorageId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        ManufacturerId = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 45),
                        Link = c.String(nullable: false, maxLength: 150),
                        Type = c.String(nullable: false, maxLength: 3),
                        Capacity = c.Int(nullable: false),
                        InterfaceId = c.Int(nullable: false),
                        Size = c.Double(nullable: false),
                        Image = c.String(nullable: false, maxLength: 45),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StorageId)
                .ForeignKey("dbo.Interface", t => t.InterfaceId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.InterfaceId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Interface",
                c => new
                    {
                        InterfaceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.InterfaceId);
            
            CreateTable(
                "dbo.Socket",
                c => new
                    {
                        SocketId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                        Description = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.SocketId);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        SeriesId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 45),
                    })
                .PrimaryKey(t => t.SeriesId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Product", "SeriesId", "dbo.Series");
            DropForeignKey("dbo.Product", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Mobo", "SocketId", "dbo.Socket");
            DropForeignKey("dbo.Cpu", "SocketId", "dbo.Socket");
            DropForeignKey("dbo.Storage", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.Storage", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Storage", "InterfaceId", "dbo.Interface");
            DropForeignKey("dbo.Build", "StorageId", "dbo.Storage");
            DropForeignKey("dbo.Ram", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.Ram", "RamTypeId", "dbo.RamType");
            DropForeignKey("dbo.Mobo", "RamTypeId", "dbo.RamType");
            DropForeignKey("dbo.Ram", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Build", "RamId", "dbo.Ram");
            DropForeignKey("dbo.Psu", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.Psu", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Psu", "FormFactorId", "dbo.FormFactor");
            DropForeignKey("dbo.Build", "PsuId", "dbo.Psu");
            DropForeignKey("dbo.Mobo", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.Gpu", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.Gpu", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Gpu", "GpuRamId", "dbo.GpuRam");
            DropForeignKey("dbo.Build", "GpuId", "dbo.Gpu");
            DropForeignKey("dbo.Cpu", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.Case", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.Cpu", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Build", "CpuId", "dbo.Cpu");
            DropForeignKey("dbo.Mobo", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Case", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Mobo", "FormFactorId", "dbo.FormFactor");
            DropForeignKey("dbo.Build", "MoboId", "dbo.Mobo");
            DropForeignKey("dbo.Case", "FormFactorId", "dbo.FormFactor");
            DropForeignKey("dbo.Build", "CaseId", "dbo.Case");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rate", "BuildId", "dbo.Build");
            DropForeignKey("dbo.Rate", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Build", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Storage", new[] { "ShopId" });
            DropIndex("dbo.Storage", new[] { "InterfaceId" });
            DropIndex("dbo.Storage", new[] { "ManufacturerId" });
            DropIndex("dbo.Ram", new[] { "ShopId" });
            DropIndex("dbo.Ram", new[] { "RamTypeId" });
            DropIndex("dbo.Ram", new[] { "ManufacturerId" });
            DropIndex("dbo.Psu", new[] { "ShopId" });
            DropIndex("dbo.Psu", new[] { "FormFactorId" });
            DropIndex("dbo.Psu", new[] { "ManufacturerId" });
            DropIndex("dbo.Gpu", new[] { "ShopId" });
            DropIndex("dbo.Gpu", new[] { "GpuRamId" });
            DropIndex("dbo.Gpu", new[] { "ProductId" });
            DropIndex("dbo.Cpu", new[] { "ShopId" });
            DropIndex("dbo.Cpu", new[] { "SocketId" });
            DropIndex("dbo.Cpu", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "SeriesId" });
            DropIndex("dbo.Product", new[] { "ManufacturerId" });
            DropIndex("dbo.Mobo", new[] { "ShopId" });
            DropIndex("dbo.Mobo", new[] { "RamTypeId" });
            DropIndex("dbo.Mobo", new[] { "SocketId" });
            DropIndex("dbo.Mobo", new[] { "FormFactorId" });
            DropIndex("dbo.Mobo", new[] { "ManufacturerId" });
            DropIndex("dbo.Case", new[] { "ShopId" });
            DropIndex("dbo.Case", new[] { "FormFactorId" });
            DropIndex("dbo.Case", new[] { "ManufacturerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Rate", new[] { "BuildId" });
            DropIndex("dbo.Rate", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Build", new[] { "CaseId" });
            DropIndex("dbo.Build", new[] { "PsuId" });
            DropIndex("dbo.Build", new[] { "StorageId" });
            DropIndex("dbo.Build", new[] { "RamId" });
            DropIndex("dbo.Build", new[] { "GpuId" });
            DropIndex("dbo.Build", new[] { "MoboId" });
            DropIndex("dbo.Build", new[] { "CpuId" });
            DropIndex("dbo.Build", new[] { "ApplicationUserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Series");
            DropTable("dbo.Socket");
            DropTable("dbo.Interface");
            DropTable("dbo.Storage");
            DropTable("dbo.RamType");
            DropTable("dbo.Ram");
            DropTable("dbo.Psu");
            DropTable("dbo.GpuRam");
            DropTable("dbo.Gpu");
            DropTable("dbo.Shop");
            DropTable("dbo.Cpu");
            DropTable("dbo.Product");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Mobo");
            DropTable("dbo.FormFactor");
            DropTable("dbo.Case");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Rate");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Build");
        }
    }
}
