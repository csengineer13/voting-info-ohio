using google_civic_api.ViewModel.Interfaces;

namespace google_civic_api.Service
{
    public partial class ViewModelServices : IViewModelServices
    {
        // Properties
        public IHomeViewModelQueryService HomeViewModelQueryService { get; private set; }
        public IHomeViewModelCommandService HomeViewModelCommandService { get; private set; }

        // Constructor
        public ViewModelServices(
            IHomeViewModelQueryService homeViewModelQueryService,
            IHomeViewModelCommandService homeViewModelCommandService)
        {
            HomeViewModelQueryService = homeViewModelQueryService;
            HomeViewModelCommandService = homeViewModelCommandService;
        }
    }
}