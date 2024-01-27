using Domain.Abstracts.Events;

namespace Domain.Abstracts.Entities
{
    public abstract class Entity<TId> where TId : IEquatable<TId>
    {
        // fields
        private readonly List<IDomainEvent> _events;
        public TId Id { get; protected set; }


        // ctor
        protected Entity()
        {
            _events = new List<IDomainEvent>();
        }

        protected void HandleEvent(IDomainEvent @event)
        {
            SetStateByEvent(@event);
            ValidateInvariants();
            _events.Add(@event);
        }


        // abstracts
        protected abstract void SetStateByEvent(IDomainEvent @event);
        protected abstract void ValidateInvariants();


        public IReadOnlyList<IDomainEvent> GetEvents() => _events;
        public void ClearEvents() => _events.Clear();


        public override bool Equals(object obj)
        {
            var other = obj as Entity<TId>;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            //if (Id == default(TId) || other.Id == default(TId))
            //    return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }


        protected void ApplyToEntity(IEntityEventApplier entity, IDomainEvent @event)
           => entity?.Apply(@event);
    }

}
