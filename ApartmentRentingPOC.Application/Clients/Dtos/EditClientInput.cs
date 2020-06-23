using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentRentingPOC.Rooms.Dtos;

namespace ApartmentRentingPOC.Clients.Dtos
{
    public class EditClientInput
    {
        public int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Nationality { get; set; }

    }
}
