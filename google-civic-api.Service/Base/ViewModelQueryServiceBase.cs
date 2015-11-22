using System;
using google_civic_api.Domain.Interfaces;
using google_civic_api.ViewModel;
using google_civic_api.ViewModel.Interfaces;

namespace google_civic_api.Service.Base
{
    //public class ViewModelQueryServiceBase<AR, VM, Dto, DDto, REPO, TId, TFilter> : ViewModelServiceBase<AR, VM, Dto, DDto, TId, TFilter>, IGenericQueryService<VM, TId>
    public class ViewModelQueryServiceBase<AR, VM, Dto, DDto, TId, TFilter> : ViewModelServiceBase<AR, VM, Dto, DDto, TId, TFilter>, IGenericQueryService<VM, TId>
        where AR : class, IAggregateRoot<TId>, new()
        where VM : IViewModelBase<Dto, DDto, TId>, new()
        where Dto : class, IDto<TId>, new()
        where DDto : class, IDto<TId>, new()
        //where REPO : IRepositorySelector<AR, TId, TFilter>
        //where TFilter : new()
    {

        //protected readonly REPO _repo;

        //public ViewModelQueryServiceBase(IUnitOfWork unitOfWork, IUser user, IRepositoryWrapper repositories, REPO repo, IDomainServices domainServices, int limit = 1000)
        //    : base(unitOfWork, user, repositories, domainServices, limit)
        public ViewModelQueryServiceBase(int limit = 1000)
            : base(limit)
        {
            //_repo = repo;
        }

        public virtual VM GetMeta(DateTime? effectiveDateTime = null)
        {
            //_vm.RootUrl = DomainServices.UtilityService.WebConfigValues.SiteRoot;
            return _vm;
        }

        public virtual VM GetDetail(TId id, DateTime? effectiveDateTime = null)
        {
            //var repo = _repo;
            //var data = repo.GetById(id);
            //_vm.ItemDetail = Mapper.Map(data, _vm.ItemDetail);
            return _vm;
        }

        public virtual VM GetMeta()
        {
           // _vm.PageInfo = Mapper.Map<PageInfoDto>(new PageInfo());
            return _vm;
        }
    }
}