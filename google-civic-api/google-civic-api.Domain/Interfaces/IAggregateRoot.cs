namespace google_civic_api.Domain.Interfaces
{
    public interface IAggregateRoot<T> : IEntityBase<T>, ICreatable, IModifiable
    {
    }
}