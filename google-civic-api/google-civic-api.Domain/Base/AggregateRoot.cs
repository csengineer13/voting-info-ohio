using google_civic_api.Domain.Interfaces;

namespace google_civic_api.Domain.Base
{
    public class AggregateRoot<T> : ModifiableEntityBase<T>, IAggregateRoot<T>
    {

    }
}