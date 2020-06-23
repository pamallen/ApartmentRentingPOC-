using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace ApartmentRentingPOC
{
    [DependsOn(typeof(AbpWebApiModule), typeof(ApartmentRentingPOCApplicationModule))]
    public class ApartmentRentingPOCWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(ApartmentRentingPOCApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
