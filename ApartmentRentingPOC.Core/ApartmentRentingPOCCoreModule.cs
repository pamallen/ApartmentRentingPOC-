using System.Reflection;
using Abp.Modules;

namespace ApartmentRentingPOC
{
    public class ApartmentRentingPOCCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
