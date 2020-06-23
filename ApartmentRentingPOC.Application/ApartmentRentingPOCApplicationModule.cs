using System.Reflection;
using Abp.Modules;

namespace ApartmentRentingPOC
{
    [DependsOn(typeof(ApartmentRentingPOCCoreModule))]
    public class ApartmentRentingPOCApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
