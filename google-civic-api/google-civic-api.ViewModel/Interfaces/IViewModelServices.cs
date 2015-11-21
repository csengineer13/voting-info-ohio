namespace google_civic_api.ViewModel.Interfaces
{
    public interface IViewModelServices
    {
        IHomeViewModelQueryService HomwViewModelQueryService { get; }
        IHomeViewModelCommandService HomwViewModelCommandService { get; }
    }
}