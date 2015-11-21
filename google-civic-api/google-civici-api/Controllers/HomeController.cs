using System.Web.Mvc;
using google_civic_api.ViewModel.Interfaces;

namespace google_civici_api.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IViewModelServices services) 
            : base(services)
        {
            
        }

        public ActionResult Index()
        {
            return View(Services.HomwViewModelQueryService.GetMeta());
        }
    }
}