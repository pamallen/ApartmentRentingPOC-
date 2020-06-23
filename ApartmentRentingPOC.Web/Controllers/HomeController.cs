using System.Web.Mvc;

namespace ApartmentRentingPOC.Web.Controllers
{
    public class HomeController : ApartmentRentingPOCControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}