using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace google_civic_api.ViewModel.Interfaces
{
    public class ServiceQueryParametersWithFilter<T, TFilter> where TFilter : new()
    {
        public ServiceQueryParametersWithFilter()
        {
            DateTime = DateTime.Now;
            SearchFilter = new TFilter();
        }

        //public List<string> Statuses { get; set; } 
        public DateTime DateTime { get; set; }
        public TFilter SearchFilter { get; set; }
        public object Options { get; set; }

        public int Id { get; set; } // Int?
        
        // ODATA
        public int Top { get; set; }
        public int Skip { get; set; }
        public string OrderBy { get; set; }

        public void SetPagin(string top, string skip, string orderby)
        {
            int topInt = 0;
            int.TryParse(top, out topInt);
            Top = topInt;

            int skipInt = 0;
            int.TryParse(skip, out skipInt);
            Skip = skipInt;

            OrderBy = orderby;
        }
    
    }
}