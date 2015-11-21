using System;

namespace google_civic_api.Domain.Interfaces
{
    public interface ICreatable
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
    }
}