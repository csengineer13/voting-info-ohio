using System;
using google_civic_api.Domain.Model.Home;
using google_civic_api.ViewModel.ViewModels;
using google_civic_api.ViewModel.ViewModels.Filter;

namespace google_civic_api.ViewModel.Interfaces
{
    public interface IHomeViewModelQueryService
    {
        HomeViewModel GetMeta(DateTime? effectiveDateTime = null);
        HomeViewModel GetDetail(Guid id, DateTime? effectiveDateTime = null);
        HomeViewModel GetMeta();
        HomeViewModel GetPage(ServiceQueryParametersWithFilter<Home, HomeSearchFilter> searchParameters);
    }
}