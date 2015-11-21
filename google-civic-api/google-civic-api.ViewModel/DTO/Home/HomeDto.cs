using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using google_civic_api.ViewModel.Interfaces;

namespace google_civic_api.ViewModel.DTO.Home
{
    public class HomeDto : IDto<Guid>
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; }
    }
}