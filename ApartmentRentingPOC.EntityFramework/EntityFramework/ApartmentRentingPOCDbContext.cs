using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using ApartmentRentingPOC.Apartments;
using ApartmentRentingPOC.Clients;
using ApartmentRentingPOC.Rooms;

namespace ApartmentRentingPOC.EntityFramework
{
    public class ApartmentRentingPOCDbContext : AbpDbContext
    {
       public virtual IDbSet<Apartment> Apartments { get; set; }
       public virtual IDbSet<Room> Rooms { get; set; }
       public virtual IDbSet<Client> Clients { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ApartmentRentingPOCDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ApartmentRentingPOCDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ApartmentRentingPOCDbContext since ABP automatically handles it.
         */
        public ApartmentRentingPOCDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public ApartmentRentingPOCDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public ApartmentRentingPOCDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
