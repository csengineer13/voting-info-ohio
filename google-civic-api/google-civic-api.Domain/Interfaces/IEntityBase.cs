using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace google_civic_api.Domain.Interfaces
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}