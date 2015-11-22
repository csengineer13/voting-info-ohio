namespace google_civic_api.ViewModel.Interfaces
{
    public interface IViewModelServices
    {
        IHomeViewModelQueryService HomeViewModelQueryService { get; }
        IHomeViewModelCommandService HomeViewModelCommandService { get; }
    }
}