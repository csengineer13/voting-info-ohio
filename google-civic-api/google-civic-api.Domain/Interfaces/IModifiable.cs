using System;

namespace google_civic_api.Domain.Interfaces
{
    public interface IModifiable
    {
        DateTime? ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }
}