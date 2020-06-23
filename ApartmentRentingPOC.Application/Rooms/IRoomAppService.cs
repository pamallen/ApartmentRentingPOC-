using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using ApartmentRentingPOC.Rooms.Dtos;

namespace ApartmentRentingPOC.Rooms
{
    public interface IRoomAppService : IApplicationService
    {
        Room CreateNewRoom(CreateNewRoomInput input);
        Room EditRoom(EditRoomInput input);
        Room GetRoom(int id);
        void DeleteRoom(int id);
    }
}
