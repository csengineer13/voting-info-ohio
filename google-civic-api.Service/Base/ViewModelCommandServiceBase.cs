using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using google_civic_api.Domain.Interfaces;
using google_civic_api.ViewModel;
using google_civic_api.ViewModel.Common;
using google_civic_api.ViewModel.Interfaces;

namespace google_civic_api.Service.Base
{
    //public abstract class ViewModelCommandServiceBase<AR, VM, Dto, DDto, REPO, TId, TFilter> : ViewModelServiceBase<AR, VM, Dto, DDto, TId, TFilter>
    public abstract class ViewModelCommandServiceBase<AR, VM, Dto, DDto, TId, TFilter> : ViewModelServiceBase<AR, VM, Dto, DDto, TId, TFilter>
        where AR : class, IAggregateRoot<TId>, new()
        where VM : IViewModelBase<Dto, DDto, TId>, new()
        where Dto : class, IDto<TId>, new()
        where DDto : class, IDto<TId>, new()
        //where REPO : IRepository<AR, TId, TFilter> where TFilter : new()
    {
        //protected readonly REPO _repop;
        protected AR _domainObject;

        public ViewModelCommandServiceBase()
        //public ViewModelCommandServiceBase(IUnitOfWork unitOfWork, IUser user, IRepositoriesWrapper repositories, REPO repo, IDomainServices domainServices)
        //    : base(unitOfWork, user, repositories, domainServices)
            : base(1000)
        {
            //_repo = repo;
        }

        public abstract TId GetDefaultIdValue();
        public abstract TId GetInsertIdValue();

        //takes a viewmodel and validates then saves
        public virtual VM SaveViewModel(VM pvm, SimpleModelState modelState, bool validateOnly = false)
        {

            _vm = pvm;
            _vm.ModelState = modelState;
            //Validate();
            //return modelState.IsValid ? (validateOnly ? _vm : ExecuteSave()) : ReturnInvalid(modelState, _vm);
            return _vm;
        }
    }
}