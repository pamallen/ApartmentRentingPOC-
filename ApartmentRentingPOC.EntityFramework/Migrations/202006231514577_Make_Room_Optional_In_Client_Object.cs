namespace ApartmentRentingPOC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Make_Room_Optional_In_Client_Object : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Clients", new[] { "RoomId" });
            AlterColumn("dbo.Clients", "RoomId", c => c.Int());
            CreateIndex("dbo.Clients", "RoomId");
            AddForeignKey("dbo.Clients", "RoomId", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Clients", new[] { "RoomId" });
            AlterColumn("dbo.Clients", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "RoomId");
            AddForeignKey("dbo.Clients", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
    }
}
