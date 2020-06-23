using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using ApartmentRentingPOC.Apartments.Dtos;
using ApartmentRentingPOC.Clients.Dtos;
using ApartmentRentingPOC.Rooms.Dtos;

namespace ApartmentRentingPOC.Clients
{
    public interface IClientAppService : IApplicationService
    {
        Client CreateNewClient(CreateNewClientInput input);
        Client EditClient(EditClientInput input);
        Client GetClient(int id);
        void DeleteClient(int id);
        void AssignRoom(int roomId, int clientId);
    }
}
