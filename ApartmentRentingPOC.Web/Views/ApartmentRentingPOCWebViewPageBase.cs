using Abp.Web.Mvc.Views;

namespace ApartmentRentingPOC.Web.Views
{
    public abstract class ApartmentRentingPOCWebViewPageBase : ApartmentRentingPOCWebViewPageBase<dynamic>
    {

    }

    public abstract class ApartmentRentingPOCWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ApartmentRentingPOCWebViewPageBase()
        {
            LocalizationSourceName = ApartmentRentingPOCConsts.LocalizationSourceName;
        }
    }
}