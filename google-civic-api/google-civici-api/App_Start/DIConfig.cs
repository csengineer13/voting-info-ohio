using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using google_civici_api.Common;
using google_civic_api.Domain.Common;
using google_civic_api.Repository.Common;
using google_civic_api.Repository.Interfaces;
using google_civic_api.Service;
using google_civic_api.ViewModel.Interfaces;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace google_civici_api.App_Start
{
    public static partial class DIConfig
    {
        private static readonly int ServicesMaxReturn = 1000;

        private static InjectionMember[] ServicesInjectionMember()
        {
            return new InjectionMember[]
            {
                // todo: DB 11/22
                //new InjectionConstructor(typeof (IUnitOfWork), typeof (IUser), typeof (IRepositoriesWrapper),
                //    ServicesMaxReturn)
            };
        }

        public static IUnityContainer RegisterComponents(WebConfigValues webConfigValues)
        {
            _container = Register(new UnityContainer(), webConfigValues);

            // Change providers and resolvers
            DependencyResolver.SetResolver(new UnityDependencyResolver(_container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(_container);
            
            // Update Filter Provider
            //var oldProvider = FilterProviders.Providers.Single(f => f is FilterAttributeFilterProvider);
            //FilterProviders.Providers.Remove(oldProvider);
            //var provider = new UnityFilterAttributeFilterProvider(_container);
            //FilterProviders.Providers.Add(provider);
            return _container;
        }

        private static UnityContainer _container;

        public static UnityContainer Register(UnityContainer container, WebConfigValues webConfigValues)
        {
            _container = container;
            //_container.RegisterInstance(new UnitOfWork(), new HttpContextDisposableLifetimeManager<UnitOfWork>());
           // _container.RegisterType<IUnitOfWork<voteContext>, UnitOfWork>();
            _container.RegisterType<IPrincipal>(new InjectionFactory(u => HttpContext.Current.User));

            RegisterAgRepositories();
            RegisterDomainServices();
            RegisterViewModelServices();

            //_container.RegisterType<IRepositoriesWrapper, RepositoriesWrapper>(new HttpContextDisposableLifetimeManager<RepositoriesWrapper>());
            _container.RegisterType<IViewModelServices, ViewModelServices>(new HttpContextDisposableLifetimeManager<ViewModelServices>());
            //_container.RegisterType<IDomainServices, DomainServices>(new HttpContextDisposableLifetimeManager<DomainServices>());
            //_container.AddNewExtension<Interception>();

            return _container;
        }
    }
}