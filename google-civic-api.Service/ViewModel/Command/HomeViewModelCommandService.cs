using System;
using google_civic_api.Domain.Model.Home;
using google_civic_api.Service.Base;
using google_civic_api.ViewModel.DTO.Home;
using google_civic_api.ViewModel.Interfaces;
using google_civic_api.ViewModel.ViewModels;
using google_civic_api.ViewModel.ViewModels.Filter;

namespace google_civic_api.Service.ViewModel.Command
{
    //public class HomeViewModelCommandService : ViewModelCommandServiceBase<Home, HomeViewModel, HomeDto, HomeDetailDto, IRepository<User, Guid, HomeSearchFilter>, Guid, HomeSearchFilter>, IHomeViewModelCommandService
    public class HomeViewModelCommandService : ViewModelCommandServiceBase<Home, HomeViewModel, HomeDto, HomeDetailDto, Guid, HomeSearchFilter>, IHomeViewModelCommandService
    {
        //public HomeViewModelCommandService(IUnitOfWork unitOfWork, IUser user, IRepositoriesWrapper repositories, IDomainServices domainServices)
        public HomeViewModelCommandService()
            : base()
        {
            
        }

        public override Guid GetDefaultIdValue()
        {
            return new Guid();
        }

        public override Guid GetInsertIdValue()
        {
            return Guid.NewGuid();
        }
    }
}