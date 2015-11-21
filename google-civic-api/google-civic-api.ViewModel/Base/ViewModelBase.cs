using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using google_civic_api.ViewModel.Common;
using google_civic_api.ViewModel.Interfaces;

namespace google_civic_api.ViewModel.Base
{
    public abstract class ViewModelBase<Dto, DDto, TId> : ViewModelNonGenericBase, IViewModelBase<Dto, DDto, TId>
        where Dto : class, IDto<TId>, new()
        where DDto : class, IDto<TId>, new()
    {
        public ViewModelBase()
        {
            List = new List<Dto>();
            Item = new Dto();
            ItemDetail = new DDto();
            PageInfo = new PageInfoDto();
            EditAction = "InsertUpdate";
        }

        public List<Dto> List { get; set; }
        public Dto Item { get; set; }
        public DDto ItemDetail { get; set; }
        public PageInfoDto PageInfo { get; set; }
        public bool ItemDetailIsNew { get; set; }

        public override List<ColumnData> Columns
        {
            get
            {
                //return ViewModelMeta.GetColumns(List);
                return new List<ColumnData>();
            }
        }

        public abstract TId GetDefaultIdValue();
        public string EditAction { get; set; }
        public string Area { get; set; }

    }
}