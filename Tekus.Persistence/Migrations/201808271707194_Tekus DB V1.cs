namespace Tekus.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TekusDBV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Nit = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.ServicesCountries",
                c => new
                    {
                        ServiceId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceId, t.CountryId })
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ServicesCountries", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.ServicesCountries", "ServiceId", "dbo.Services");
            DropIndex("dbo.ServicesCountries", new[] { "CountryId" });
            DropIndex("dbo.ServicesCountries", new[] { "ServiceId" });
            DropIndex("dbo.Services", new[] { "CustomerId" });
            DropTable("dbo.ServicesCountries");
            DropTable("dbo.Customers");
            DropTable("dbo.Services");
            DropTable("dbo.Countries");
        }
    }
}
