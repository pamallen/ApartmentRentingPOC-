using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using ApartmentRentingPOC.Apartments.Dtos;
using ApartmentRentingPOC.Rooms;
using ApartmentRentingPOC.Rooms.Dtos;

namespace ApartmentRentingPOC.Apartments
{
    public class ApartmentAppService : ApartmentRentingPOCAppServiceBase, IApartmentAppService
    {
        private readonly IRepository<Apartment> _apartmentRepository;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRoomAppService _roomService;

        public ApartmentAppService(IRepository<Apartment> apartmentRepository,
            IRepository<Room> roomRepository,
            IRoomAppService roomService)
        {
            _apartmentRepository = apartmentRepository;
            _roomRepository = roomRepository;
            _roomService = roomService;
        }

        public Apartment CreateNewApartment(CreateNewApartmentInput input)
        {
            var rooms = new List<Room>();

            foreach (var inputRoom in input.Rooms)
            {
                // We create a new room
                var newRoom = _roomService.CreateNewRoom(new CreateNewRoomInput
                {
                    Room = inputRoom
                }); 

                rooms.Add(newRoom); // We add the new room to our apartment to be created
            }

            var apartment = Apartment.Create(input.Name,
                input.Street,
                input.ZipCode,
                input.City,
                rooms);

            _apartmentRepository.Insert(apartment);

            return apartment;
        }
        public Apartment EditApartment(EditApartmentInput input)
        {
            var existingApartment = _apartmentRepository.Get(input.Id);

            if (existingApartment == null)
            {
                throw new UserFriendlyException("This apartment doesn't exist");
            }

            //For each room in input, we verify it exists in the apartment or we add it
            foreach (var inputRoom in input.Rooms)
            {
                var existingRoom = _roomRepository.FirstOrDefault(r => r.Id == inputRoom.Id);
                if (existingRoom == null)
                {
                    var newRoom = _roomService.CreateNewRoom(new CreateNewRoomInput
                    {
                        Room = inputRoom
                    });
                    existingApartment.Rooms.Add(newRoom);
                }
            }

            //We remove rooms that are not included in the edit input, as we assume they are not in the apartment anymore
            foreach (var existingRoom in existingApartment.Rooms)
            {
                if (!input.Rooms.Any(r => r.Id == existingRoom.Id))
                {
                    _roomService.DeleteRoom(existingRoom.Id);
                }
            }

            //We verify there is still at least one room in the apartment
            if (existingApartment.Rooms.Count == 0)
            {
                throw new UserFriendlyException("An apartment must have at least one room");
            }

            existingApartment.Name = input.Name;
            existingApartment.Street = input.Street;
            existingApartment.ZipCode = input.Name;
            existingApartment.City = input.Name;

            _apartmentRepository.Update(existingApartment);

            return existingApartment;
        }

        public Apartment GetApartment(int id)
        {
            var existingApartment = _apartmentRepository.FirstOrDefault(a => a.Id == id);

            if (existingApartment == null)
            {
                throw new UserFriendlyException("This apartment doesn't exist");
            }

            return existingApartment;
        }

        public void DeleteApartment(int id)
        {
            var existingApartment = _apartmentRepository.FirstOrDefault(a => a.Id == id);

            if (existingApartment == null)
            {
                throw new UserFriendlyException("This apartment doesn't exist");
            }
          
            foreach (var existingApartmentRoom in existingApartment.Rooms)
            {
                _roomRepository.Delete(existingApartmentRoom);
            }
            _apartmentRepository.Delete(a => a.Id == id);
        }
    }
}
