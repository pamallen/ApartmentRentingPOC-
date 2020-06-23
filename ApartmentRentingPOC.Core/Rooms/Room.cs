using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using ApartmentRentingPOC.Apartments;
using ApartmentRentingPOC.Clients;

namespace ApartmentRentingPOC.Rooms
{
    public class Room : Entity
    {
        public virtual int Number { get; set; }
        public virtual float Area { get; set; }
        public virtual int Price { get; set; }

        /// <summary>
        /// We do not make constructor public to force creating this entity using the <see cref="Create"/> method.
        /// Since the constructor can not be private because it is used by EntityFramework we make it protected.
        /// </summary>
        protected Room()
        {

        }

        public static Room Create(int number,
            float area,
            int price)
        {
            return new Room
            {
                Number = number,
                Area = area,
                Price = price
            };
        }
    }
}
