
namespace Domain.Abstracts.ValueObjects
{
    public abstract class ValueObject<TValueObject> : IEquatable<TValueObject>
    where TValueObject : ValueObject<TValueObject>
    {
        public override bool Equals(object obj)
        {
            var otherObject = obj as TValueObject;
            if (ReferenceEquals(obj, null))
                return false;
            return ObjectIsEqual(otherObject);
        }

        public override int GetHashCode()
        {
            return ObjectGetHashCode();
        }

        public abstract bool ObjectIsEqual(TValueObject otherObject);
        public abstract int ObjectGetHashCode();

        public bool Equals(TValueObject other)
        {
            return this == other;
        }

        public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            if (ReferenceEquals(right, null) && ReferenceEquals(left, null))
                return true;
            if (ReferenceEquals(right, null) || ReferenceEquals(left, null))
                return false;
            return right.Equals(left);
        }

        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return !(right == left);
        }
    }
}
