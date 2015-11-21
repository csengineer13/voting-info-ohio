using System;
using google_civic_api.Domain.Interfaces;

namespace google_civic_api.Domain.Base
{
    public class ModifiableEntityBase<T> : EntityBase<T>, IModifiable
    {
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}