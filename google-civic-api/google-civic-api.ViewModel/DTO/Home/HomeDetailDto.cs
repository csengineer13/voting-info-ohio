using System;
using google_civic_api.ViewModel.Interfaces;

namespace google_civic_api.ViewModel.DTO.Home
{
    public class HomeDetailDto : IDto<Guid>
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; }
    }
}