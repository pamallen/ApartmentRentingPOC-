using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentRentingPOC.Rooms.Dtos;

namespace ApartmentRentingPOC.Apartments.Dtos
{
    public class EditApartmentInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public IList<RoomDto> Rooms { get; set; } = new List<RoomDto>();

    }
}
