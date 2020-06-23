using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using ApartmentRentingPOC.Rooms;

namespace ApartmentRentingPOC.Clients
{
    public class Client : Entity

    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Nationality { get; set; }
        public virtual Room Room { get; set; }

        /// <summary>
        /// We do not make constructor public to force creating this entity using the <see cref="Create"/> method.
        /// Since the constructor can not be private because it is used by EntityFramework we make it protected.
        /// </summary>
        protected Client()
        {

        }

        public static Client Create(string firstName,
            string lastName,
            string email,
            string phone,
            DateTime birthDate,
            string nationality)
        {
            return new Client
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                BirthDate = birthDate,
                Nationality = nationality
            };
        }
    }
}
