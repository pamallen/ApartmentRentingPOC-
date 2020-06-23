using System.Linq;
using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Swashbuckle.Application;

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

            ConfigureSwaggerUi();
        }

        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "ApartmentRentingPOC.WebApi");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                })
                .EnableSwaggerUi(c =>
                {
                    c.InjectJavaScript(Assembly.GetAssembly(typeof(ApartmentRentingPOCWebApiModule)), "ApartmentRentingPOC.Api.Scripts.Swagger-Custom.js");
                });
        }
    }
}
