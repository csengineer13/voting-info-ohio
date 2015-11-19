using System.Collections.Generic;
using System.Linq;

namespace google_civic_api.ViewModel.Common
{
    public class KOMapping
    {
        public KOMapping()
        {
            ignore = new List<string>();
            ignorePostBack = new List<string>();
            copy = new List<string>() { "KOMapping.copy", "Meta" };
        }
        public List<string> ignore { get; set; }
        public List<string> copy { get; set; }
        public List<string> ignorePostBack { get; set; }
        public List<string> allNonPostBack
        {
            get { return copy.Union(ignorePostBack).ToList(); }
        }
    }
}