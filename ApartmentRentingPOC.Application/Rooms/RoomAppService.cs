using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;
using ApartmentRentingPOC.Apartments;
using ApartmentRentingPOC.Apartments.Dtos;
using ApartmentRentingPOC.Rooms;
using ApartmentRentingPOC.Rooms.Dtos;

namespace ApartmentRentingPOC.Rooms
{
    public class RoomAppService : ApartmentRentingPOCAppServiceBase, IRoomAppService
    {
        private readonly IRepository<Apartment> _apartmentRepository;
        private readonly IRepository<Room> _roomRepository;

        public RoomAppService(IRepository<Apartment> apartmentRepository,
            IRepository<Room> roomRepository)
        {
            _apartmentRepository = apartmentRepository;
            _roomRepository = roomRepository;
        }

        public Room CreateNewRoom(CreateNewRoomInput input)
        {
            var room = Room.Create(input.Room.Number,
                input.Room.Area,
                input.Room.Price);

            _roomRepository.Insert(room);

            return room;
        }

        public Room EditRoom(EditRoomInput input)
        {
            var existingRoom = _roomRepository.Get(input.Room.Id);

            if (existingRoom == null)
            {
                throw new UserFriendlyException("This room doesn't exist");
            }

            existingRoom.Number = input.Room.Number;
            existingRoom.Area = input.Room.Area;
            existingRoom.Price = input.Room.Price;
            _roomRepository.Update(existingRoom);

            return existingRoom;
        }

        public Room GetRoom(int id)
        {
            var existingRoom = _roomRepository.FirstOrDefault(r => r.Id == id);

            if (existingRoom == null)
            {
                throw new UserFriendlyException("This room doesn't exist");
            }

            return existingRoom;
        }

        public void DeleteRoom(int id)
        {
            var existingRoom = _roomRepository.FirstOrDefault(r => r.Id == id);

            if (existingRoom == null)
            {
                throw new UserFriendlyException("This room doesn't exist");
            }

            var existingApartment = _apartmentRepository.FirstOrDefault(a => a.Rooms.Any(r => r.Id == id));

            if (existingApartment.Rooms.Count == 1)
            {
                throw new UserFriendlyException("You can't delete a room if it is the only room for an apartment ! Please delete the apartment itself");
            }

            _roomRepository.Delete(r => r.Id == id);
        }
    }
}
