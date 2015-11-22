using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace google_civic_api.ViewModel.Interfaces
{
    public interface IGenericQueryService<T, TId>
    {
        T GetMeta(DateTime? effectiveDateTime = null);
        T GetDetail(TId id, DateTime? effectiveDateTime = null);
        T GetMeta();
    }
}