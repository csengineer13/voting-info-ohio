using google_civic_api.ViewModel.Common;

namespace google_civic_api.ViewModel.Interfaces
{
    public interface IQueryServiceBase<TViewModel>
    {
        TViewModel SaveViewModel(TViewModel pvm, SimpleModelState modelState, bool validateOnly = false);
    }
}