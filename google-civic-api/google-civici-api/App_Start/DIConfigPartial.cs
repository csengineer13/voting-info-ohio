using google_civici_api.Common;
using google_civic_api.Service.ViewModel.Query;
using google_civic_api.ViewModel.Interfaces;
using Microsoft.Practices.Unity;

namespace google_civici_api.App_Start
{
    public static partial class DIConfig
    {
        private static void RegisterViewModelServices()
        {
            _container.RegisterType<IHomeViewModelQueryService, HomeViewModelQueryService>(new HttpContextDisposableLifetimeManager<HomeViewModelQueryService>());
            _container.RegisterType<IHomeViewModelCommandService, HomeViewModelCommandService>(new HttpContextDisposableLifetimeManager<HomeViewModelCommandService>());
        }

        private static void RegisterDomainServices()
        {
            
        }

        private static void RegisterAgRepositories()
        {
            
        }
    }
}