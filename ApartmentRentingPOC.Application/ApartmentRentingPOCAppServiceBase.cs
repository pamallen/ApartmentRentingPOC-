using Abp.Application.Services;

namespace ApartmentRentingPOC
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ApartmentRentingPOCAppServiceBase : ApplicationService
    {
        protected ApartmentRentingPOCAppServiceBase()
        {
            LocalizationSourceName = ApartmentRentingPOCConsts.LocalizationSourceName;
        }
    }
}