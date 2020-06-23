using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using ApartmentRentingPOC.EntityFramework;

namespace ApartmentRentingPOC
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(ApartmentRentingPOCCoreModule))]
    public class ApartmentRentingPOCDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<ApartmentRentingPOCDbContext>(null);
        }
    }
}
