using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ApartmentRentingPOC.Rooms.Dtos
{
    [AutoMap(typeof(Room))]
    public class RoomDto: EntityDto
    {
        public virtual int Number { get; set; }
        public virtual float Area { get; set; }
        public virtual int Price { get; set; }
    }
}
