namespace Domain.Abstracts.Events
{
    public interface IEntityEventApplier
    {
        void Apply(IDomainEvent @event);
    }
}
