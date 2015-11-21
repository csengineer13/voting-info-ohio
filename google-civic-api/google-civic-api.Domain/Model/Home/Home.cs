using System;
using google_civic_api.Domain.Base;

namespace google_civic_api.Domain.Model.Home
{
    public class Home: AggregateRoot<Guid>
    {
        public Home()
        {
            
        }

        // value 
        public string Name { get; set; }
    }
}