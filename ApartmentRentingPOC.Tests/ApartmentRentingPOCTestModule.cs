using System.Linq;
using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.TestBase;

namespace ApartmentRentingPOC
{
    [DependsOn(
        typeof(ApartmentRentingPOCDataModule),
        typeof(ApartmentRentingPOCApplicationModule),
        typeof(AbpTestBaseModule)
    )]
    public class ApartmentRentingPOCTestModule : AbpModule
    {

    }
}
