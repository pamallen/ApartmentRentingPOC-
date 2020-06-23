using Abp.Web.Mvc.Controllers;

namespace ApartmentRentingPOC.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class ApartmentRentingPOCControllerBase : AbpController
    {
        protected ApartmentRentingPOCControllerBase()
        {
            LocalizationSourceName = ApartmentRentingPOCConsts.LocalizationSourceName;
        }
    }
}