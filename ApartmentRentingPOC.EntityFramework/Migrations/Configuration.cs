using System.Data.Entity.Migrations;

namespace ApartmentRentingPOC.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApartmentRentingPOC.EntityFramework.ApartmentRentingPOCDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ApartmentRentingPOC";
        }

        protected override void Seed(ApartmentRentingPOC.EntityFramework.ApartmentRentingPOCDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
