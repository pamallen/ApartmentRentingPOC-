using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Net.Mime;
using System.Text;
using ApartmentRentingPOC.Clients;
using ApartmentRentingPOC.Clients.Dtos;
using Shouldly;
using Xunit;

namespace ApartmentRentingPOC.Tests.ClientAppService
{
    public class CreateNewClientTest : ApartmentRentingPOCTestBase
    {
        private readonly IClientAppService _clientAppService;

        public CreateNewClientTest()
        {
            _clientAppService = LocalIocManager.Resolve<IClientAppService>();
        }

        [Fact]
        public void Should_Create_A_Client()
        {
            //ARRANGE
            var input = new CreateNewClientInput
            {
                FirstName = "Test",
                LastName = "Client",
                Email = "testemail@test.com",
                Phone = "11111",
                Nationality = "French"
            };

            //ACT
            var result = _clientAppService.CreateNewClient(input);

            //ASSERT
            UsingDbContext(context =>
            {
                context.Clients.Count().ShouldBe(1);
            });
        }
    }
}
