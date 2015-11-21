using System;
using google_civic_api.ViewModel.Base;
using google_civic_api.ViewModel.DTO.Home;
using google_civic_api.ViewModel.ViewModels.Meta;

namespace google_civic_api.ViewModel.ViewModels
{
    public class HomeViewModel : ViewModelBase<HomeDto, HomeDetailDto, Guid>
    {
        public HomeViewModel()
        {
            Title = "Home";
        }

        public override Guid GetDefaultIdValue()
        {
            return new Guid();
        }

        public HomeViewModelMeta Meta { get; set; }
    }
}