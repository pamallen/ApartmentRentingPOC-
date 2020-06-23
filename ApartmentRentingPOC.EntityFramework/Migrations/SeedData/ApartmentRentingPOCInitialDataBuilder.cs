using System.Collections.Generic;
using ApartmentRentingPOC.Apartments;
using ApartmentRentingPOC.EntityFramework;
using ApartmentRentingPOC.Rooms;

namespace ApartmentRentingPOC.Migrations.SeedData
{
    public class ApartmentRentingPOCInitialDataBuilder
    {
        public void Build(ApartmentRentingPOCDbContext context)
        {
            //Add a room
            var rooms = new List<Room>();
                rooms.Add(Room.Create(1, 2, 3));
            //Add an apartment            
            context.Apartments.Add(Apartment.Create("testname",
                "teststreet",
                "testzipcode",
                "testcity",
                rooms));
            context.SaveChanges();
        }
    }
}
