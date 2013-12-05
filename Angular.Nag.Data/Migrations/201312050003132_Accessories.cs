namespace Angular.Nag.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Accessories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ChargerType = c.Int(),
                        CordLength = c.Int(),
                        Color = c.String(),
                        Category = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AccessoryId);
            
            CreateTable(
                "dbo.AccessoryPhones",
                c => new
                    {
                        Accessory_AccessoryId = c.Int(nullable: false),
                        Phone_PhoneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Accessory_AccessoryId, t.Phone_PhoneId })
                .ForeignKey("dbo.Accessories", t => t.Accessory_AccessoryId, cascadeDelete: true)
                .ForeignKey("dbo.Phones", t => t.Phone_PhoneId, cascadeDelete: true)
                .Index(t => t.Accessory_AccessoryId)
                .Index(t => t.Phone_PhoneId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AccessoryPhones", new[] { "Phone_PhoneId" });
            DropIndex("dbo.AccessoryPhones", new[] { "Accessory_AccessoryId" });
            DropForeignKey("dbo.AccessoryPhones", "Phone_PhoneId", "dbo.Phones");
            DropForeignKey("dbo.AccessoryPhones", "Accessory_AccessoryId", "dbo.Accessories");
            DropTable("dbo.AccessoryPhones");
            DropTable("dbo.Accessories");
        }
    }
}
