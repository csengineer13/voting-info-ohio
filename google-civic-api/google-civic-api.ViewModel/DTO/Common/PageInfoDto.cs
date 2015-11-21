using System;
using google_civic_api.ViewModel.Interfaces;

namespace google_civic_api.ViewModel
{
    public class PageInfoDto : IDto<Guid>
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; }
        public long PageCount { get; set; }
        public long TotalItemCount { get; set; }
        public long PageNumber { get; set; }
        public long PageSize { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public long FirstItemOnPage { get; set; }
        public long LastItemOnPage { get; set; }

        public string Page1 { get; set; }
        public string Page2 { get; set; }
        public string Page3 { get; set; }
        public string Page4 { get; set; }
        public string Page5 { get; set; }
    }
}