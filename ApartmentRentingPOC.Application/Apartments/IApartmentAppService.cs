using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using ApartmentRentingPOC.Apartments.Dtos;
using ApartmentRentingPOC.Rooms.Dtos;

namespace ApartmentRentingPOC.Apartments
{
    public interface IApartmentAppService : IApplicationService
    {
        Apartment CreateNewApartment(CreateNewApartmentInput input);
        Apartment EditApartment(EditApartmentInput input);
        Apartment GetApartment(int id);
        void DeleteApartment(int id);

    }
}
