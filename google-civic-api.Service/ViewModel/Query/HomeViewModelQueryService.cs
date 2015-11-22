using System;
using System.Collections.Generic;
using System.Web.UI;
using google_civic_api.Domain.Model.Home;
using google_civic_api.Service.Base;
using google_civic_api.ViewModel;
using google_civic_api.ViewModel.DTO.Home;
using google_civic_api.ViewModel.Interfaces;
using google_civic_api.ViewModel.ViewModels;
using google_civic_api.ViewModel.ViewModels.Filter;

namespace google_civic_api.Service.ViewModel.Query
{
    //public class HomeViewModelQueryService : ViewModelQueryServiceBase<Home, HomeViewModel, HomeDto, HomeDetailDto, IHomeRepository, Guid, HomeSearchFilter>, IHomeViewModelQueryService
    public class HomeViewModelQueryService : ViewModelQueryServiceBase<Home, HomeViewModel, HomeDto, HomeDetailDto, Guid, HomeSearchFilter>, IHomeViewModelQueryService
    {
        //public HomeViewModelQueryService(IUnitOfWork unitOfWork, IUserControlDesignerAccessor user, IRepositoriesWrapper repositories, IDomainServices domainServices)
        //    : base(unitOfWork, user, repositories, repositories.HomeRepository, domainServices, 1000)
        public HomeViewModelQueryService()
            :base(1000)
        {
            
        }

        public override HomeViewModel GetMeta()
        {
            var vm = base.GetMeta();
            return vm;
        }

        public new HomeViewModel GetDetail(Guid id, DateTime? effectiveDateTime)
        {
            var vm = base.GetDetail(id, effectiveDateTime);
            return vm;
        }

        public HomeViewModel GetPage(ServiceQueryParametersWithFilter<Home, HomeSearchFilter> searchParameters)
        {
            var vm = new HomeViewModel();

            //var listWithPageInfo = _repo.GetPage(searchParameters);
            //vm.List = Mapper.Map<List<HomeDto>>(listWithPageInfo.List);
            //vm.PageInfo = Mapper.Map<PageInfoDto>(listWithPageInfo.PageInfo);

            return vm;
        }
    }
}