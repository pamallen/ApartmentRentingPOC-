using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;
using ApartmentRentingPOC.Apartments;
using ApartmentRentingPOC.Apartments.Dtos;
using ApartmentRentingPOC.Clients.Dtos;
using ApartmentRentingPOC.Rooms;
using ApartmentRentingPOC.Rooms.Dtos;

namespace ApartmentRentingPOC.Clients
{
    public class ClientAppService : ApartmentRentingPOCAppServiceBase, IClientAppService
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Apartment> _apartmentRepository;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRoomAppService _roomService;

        public ClientAppService(IRepository<Client> clientRepository, 
            IRepository<Apartment> apartmentRepository,
            IRepository<Room> roomRepository,
            IRoomAppService roomService)
        {
            _clientRepository = clientRepository;
            _apartmentRepository = apartmentRepository;
            _roomRepository = roomRepository;
            _roomService = roomService;
        }

        public Client CreateNewClient(CreateNewClientInput input)
        {
            var existingEmail = _clientRepository.FirstOrDefault(c => c.Email == input.Email);
            if (existingEmail != null)
            {
                throw new UserFriendlyException("This email address is already used !");
            }

            var client = Client.Create(input.FirstName,
                input.LastName,
                input.Email,
                input.Phone,
                input.BirthDate,
                input.Nationality);

            _clientRepository.Insert(client);

            return client;
        }
        public Client EditClient(EditClientInput input)
        {
            var existingClient = _clientRepository.FirstOrDefault(input.Id);
            if (existingClient == null)
            {
                throw new UserFriendlyException("This client doesn't exist");
            }

            var existingEmail = _clientRepository.FirstOrDefault(c => c.Email == input.Email && c.Id != input.Id);
            if (existingEmail != null)
            {
                throw new UserFriendlyException("This email address is already used !");
            }

            existingClient.FirstName = input.FirstName;
            existingClient.LastName = input.LastName;
            existingClient.Email = input.Email;
            existingClient.Phone = input.Phone;
            existingClient.BirthDate = input.BirthDate;
            existingClient.Nationality = input.Nationality;

            _clientRepository.Update(existingClient);

            return existingClient;
        }

        public Client GetClient(int id)
        {
            var existingClient = _clientRepository.FirstOrDefault(id);

            if (existingClient == null)
            {
                throw new UserFriendlyException("This client doesn't exist");
            }

            return existingClient;
        }

        public void DeleteClient(int id)
        {
            var existingClient = _clientRepository.FirstOrDefault(id);

            if (existingClient == null)
            {
                throw new UserFriendlyException("This client doesn't exist");
            }
            
            _clientRepository.Delete(c => c.Id == id);
        }

        public void AssignRoom(int roomId, int clientId)
        {
            var existingClient = _clientRepository.FirstOrDefault(clientId);
            if (existingClient == null)
            {
                throw new UserFriendlyException("This client doesn't exist");
            }

            CheckCompleteClientProfile(existingClient);

            var existingRoom = _roomRepository.FirstOrDefault(roomId);
            if (existingRoom == null)
            {
                throw new UserFriendlyException("This room doesn't exist");
            }

            var existingOccupant = _clientRepository.FirstOrDefault(c => c.RoomId == existingRoom.Id);
            if (existingOccupant != null)
            {
                throw new UserFriendlyException("This room is already taken");
            }

            existingClient.Room = existingRoom;
            _clientRepository.Update(existingClient);
        }

        private void CheckCompleteClientProfile(Client client)
        {
            var predicate = string.IsNullOrEmpty(client.FirstName)
                            || string.IsNullOrEmpty(client.LastName)
                            || string.IsNullOrEmpty(client.Email)
                            || string.IsNullOrEmpty(client.Phone)
                            || client.BirthDate == null
                            || string.IsNullOrEmpty(client.Nationality);

            if (predicate)
            {
                throw new UserFriendlyException("The client profile isn't complete");
            }
        }
    }
}
