using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using ApartmentRentingPOC.Rooms;

namespace ApartmentRentingPOC.Apartments
{
    public class Apartment : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Street { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string City { get; set; }
        public virtual IList<Room> Rooms { get; protected set; } = new List<Room>();

        /// <summary>
        /// We do not make constructor public to force creating this entity using the <see cref="Create"/> method.
        /// Since the constructor can not be private because it is used by EntityFramework we make it protected.
        /// </summary>
        protected Apartment()
        {

        }

        public static Apartment Create(string name,
            string street,
            string zipcode,
            string city,
            List<Room> rooms)
        {

            if (rooms.Count == 0)
            {
                throw new ArgumentException("Apartments require at least one room");
            }

            return new Apartment
            {
                Name = name,
                Street = street,
                City = city,
                ZipCode = zipcode,
                Rooms = rooms
            };
        }
    }
}
