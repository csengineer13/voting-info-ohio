using System.Collections.Generic;
using System.Net;
using google_civic_api.ViewModel.Common;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace google_civic_api.ViewModel
{
    public abstract class ViewModelNonGenericBase
    {

        public ViewModelNonGenericBase()
        {
            ModelState = new SimpleModelState();
            KOMapping = new KOMapping();
            StatusCode = (int)HttpStatusCode.OK;
            HasDialog = false;
            HasAlerts = true;
            Title = "";
            //User = new LoggedInUserDto();
            DefaultSammyRoute = "list";
        }

        public string PageContentId { get; set; }
        public abstract List<ColumnData> Columns { get; }

        //
        public bool HasAlerts { get; set; }
        public bool HasDialog { get; set; }
        public bool HasExport { get; set; }
        public bool ModalOpen { get; set; }
        public bool AllowEditing { get; set; }
        public bool IsLoading { get; set; }
        public bool IsRowLoading { get; set; }
        public bool IsTableLoading { get; set; }

        public string DefaultSammyRoute { get; set; }
        public int StatusCode { get; set; }

        public KOMapping KOMapping { get; set; }
        public SimpleModelState ModelState { get; set; }
        public string Message { get; set; }
        public string RedirectResponse { get; set; }
        public string Title { get; set; }
        public string FrontEndRoute { get; set; }
        //public LoggedInUserDto User { get; set; }
        public string WindowLocation { get; set; }

        // Quick Convert VM to JSON rep
        public string ToJson()
        {
            var json = JsonConvert.SerializeObject(this,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return json;
        }

    }
}

