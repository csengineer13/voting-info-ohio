using System;
using google_civic_api.Domain.Interfaces;

namespace google_civic_api.Domain.Base
{
    public class EntityBase<T> : IEntityBase<T>, ICreatable
    {
        public EntityBase()
        {
            CreatedDate = DateTime.Now;
            CreatedBy = "System";
        }

        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}