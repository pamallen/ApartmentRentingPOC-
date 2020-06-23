namespace ApartmentRentingPOC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_Room_to_Client_object : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.Clients", new[] { "Room_Id" });
            RenameColumn(table: "dbo.Clients", name: "Room_Id", newName: "RoomId");
            AlterColumn("dbo.Clients", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Clients", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "RoomId");
            AddForeignKey("dbo.Clients", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Clients", new[] { "RoomId" });
            AlterColumn("dbo.Clients", "RoomId", c => c.Int());
            AlterColumn("dbo.Clients", "BirthDate", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.Clients", name: "RoomId", newName: "Room_Id");
            CreateIndex("dbo.Clients", "Room_Id");
            AddForeignKey("dbo.Clients", "Room_Id", "dbo.Rooms", "Id");
        }
    }
}
