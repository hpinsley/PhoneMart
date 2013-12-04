namespace Angular.Nag.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        ManufacturerName = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ImageFile = c.String(),
                        Manufacturer_ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_ManufacturerId, cascadeDelete: true)
                .Index(t => t.Manufacturer_ManufacturerId);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        PlanName = c.String(),
                        MonthlyCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoiceMinutes = c.Int(nullable: false),
                        DataMegabytes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId);
            
            CreateTable(
                "dbo.Apps",
                c => new
                    {
                        AppId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AppId);
            
            CreateTable(
                "dbo.PhoneInstances",
                c => new
                    {
                        PhoneInstanceId = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Phone_PhoneId = c.Int(),
                        PhonePlan_PlanId = c.Int(),
                        Account_AccountId = c.Int(),
                    })
                .PrimaryKey(t => t.PhoneInstanceId)
                .ForeignKey("dbo.Phones", t => t.Phone_PhoneId)
                .ForeignKey("dbo.Plans", t => t.PhonePlan_PlanId)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountId)
                .Index(t => t.Phone_PhoneId)
                .Index(t => t.PhonePlan_PlanId)
                .Index(t => t.Account_AccountId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        ContactPhoneNumber = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountHolder_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.People", t => t.AccountHolder_PersonId, cascadeDelete: true)
                .Index(t => t.AccountHolder_PersonId);
            
            CreateTable(
                "dbo.PhonePlans",
                c => new
                    {
                        Phone_PhoneId = c.Int(nullable: false),
                        Plan_PlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Phone_PhoneId, t.Plan_PlanId })
                .ForeignKey("dbo.Phones", t => t.Phone_PhoneId, cascadeDelete: true)
                .ForeignKey("dbo.Plans", t => t.Plan_PlanId, cascadeDelete: true)
                .Index(t => t.Phone_PhoneId)
                .Index(t => t.Plan_PlanId);
            
            CreateTable(
                "dbo.PhoneInstanceApps",
                c => new
                    {
                        PhoneInstance_PhoneInstanceId = c.Int(nullable: false),
                        App_AppId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PhoneInstance_PhoneInstanceId, t.App_AppId })
                .ForeignKey("dbo.PhoneInstances", t => t.PhoneInstance_PhoneInstanceId, cascadeDelete: true)
                .ForeignKey("dbo.Apps", t => t.App_AppId, cascadeDelete: true)
                .Index(t => t.PhoneInstance_PhoneInstanceId)
                .Index(t => t.App_AppId);
            
            CreateTable(
                "dbo.PhoneApps",
                c => new
                    {
                        Phone_PhoneId = c.Int(nullable: false),
                        App_AppId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Phone_PhoneId, t.App_AppId })
                .ForeignKey("dbo.Phones", t => t.Phone_PhoneId, cascadeDelete: true)
                .ForeignKey("dbo.Apps", t => t.App_AppId, cascadeDelete: true)
                .Index(t => t.Phone_PhoneId)
                .Index(t => t.App_AppId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PhoneApps", new[] { "App_AppId" });
            DropIndex("dbo.PhoneApps", new[] { "Phone_PhoneId" });
            DropIndex("dbo.PhoneInstanceApps", new[] { "App_AppId" });
            DropIndex("dbo.PhoneInstanceApps", new[] { "PhoneInstance_PhoneInstanceId" });
            DropIndex("dbo.PhonePlans", new[] { "Plan_PlanId" });
            DropIndex("dbo.PhonePlans", new[] { "Phone_PhoneId" });
            DropIndex("dbo.Accounts", new[] { "AccountHolder_PersonId" });
            DropIndex("dbo.PhoneInstances", new[] { "Account_AccountId" });
            DropIndex("dbo.PhoneInstances", new[] { "PhonePlan_PlanId" });
            DropIndex("dbo.PhoneInstances", new[] { "Phone_PhoneId" });
            DropIndex("dbo.Phones", new[] { "Manufacturer_ManufacturerId" });
            DropForeignKey("dbo.PhoneApps", "App_AppId", "dbo.Apps");
            DropForeignKey("dbo.PhoneApps", "Phone_PhoneId", "dbo.Phones");
            DropForeignKey("dbo.PhoneInstanceApps", "App_AppId", "dbo.Apps");
            DropForeignKey("dbo.PhoneInstanceApps", "PhoneInstance_PhoneInstanceId", "dbo.PhoneInstances");
            DropForeignKey("dbo.PhonePlans", "Plan_PlanId", "dbo.Plans");
            DropForeignKey("dbo.PhonePlans", "Phone_PhoneId", "dbo.Phones");
            DropForeignKey("dbo.Accounts", "AccountHolder_PersonId", "dbo.People");
            DropForeignKey("dbo.PhoneInstances", "Account_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.PhoneInstances", "PhonePlan_PlanId", "dbo.Plans");
            DropForeignKey("dbo.PhoneInstances", "Phone_PhoneId", "dbo.Phones");
            DropForeignKey("dbo.Phones", "Manufacturer_ManufacturerId", "dbo.Manufacturers");
            DropTable("dbo.PhoneApps");
            DropTable("dbo.PhoneInstanceApps");
            DropTable("dbo.PhonePlans");
            DropTable("dbo.Accounts");
            DropTable("dbo.People");
            DropTable("dbo.PhoneInstances");
            DropTable("dbo.Apps");
            DropTable("dbo.Plans");
            DropTable("dbo.Phones");
            DropTable("dbo.Manufacturers");
        }
    }
}
