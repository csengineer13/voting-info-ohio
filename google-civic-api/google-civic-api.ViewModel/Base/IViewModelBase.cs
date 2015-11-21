using System;
using System.Collections.Generic;
using google_civic_api.ViewModel.Common;
using google_civic_api.ViewModel.Interfaces;

namespace google_civic_api.ViewModel
{
    public interface IViewModelBase<Dto, DDto, TId>
        where Dto : class, IDto<TId>, new()
        where DDto : class, IDto<TId>, new()
    {
        List<Dto> List { get; set; }
        SimpleModelState ModelState { get; set; }
        int StatusCode { get; set; }
        string Message { get; set; }
        Dto Item { get; set; }
        DDto ItemDetail { get; set; }
        List<ColumnData> Columns { get; }
        KOMapping KOMapping { get; set; }
        string ToJson();
        bool ItemDetailIsNew { get; set; }
        string Title { get; set; }
        //LoggedInUserDto User { get; set; }
        PageInfoDto PageInfo { get; set; }
    }
}