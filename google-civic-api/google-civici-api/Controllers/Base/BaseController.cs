using System.Web.Mvc;
using google_civic_api.ViewModel.Interfaces;

namespace google_civici_api.Controllers
{
    public class BaseController : AsyncController
    {
        public readonly IViewModelServices Services;

        public BaseController(IViewModelServices services)
        {
            Services = services;
        }
    }
}