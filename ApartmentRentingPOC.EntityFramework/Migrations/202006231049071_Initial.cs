namespace ApartmentRentingPOC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Area = c.Single(nullable: false),
                        Price = c.Int(nullable: false),
                        Apartment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartments", t => t.Apartment_Id)
                .Index(t => t.Apartment_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Nationality = c.String(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Apartment_Id", "dbo.Apartments");
            DropIndex("dbo.Clients", new[] { "Room_Id" });
            DropIndex("dbo.Rooms", new[] { "Apartment_Id" });
            DropTable("dbo.Clients");
            DropTable("dbo.Rooms");
            DropTable("dbo.Apartments");
        }
    }
}
