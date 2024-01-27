using Domain.Abstracts.ValueObjects;

namespace Domain.Shared.ValueObjects
{
    public class Price : ValueObject<Price>
    {
        public decimal Value { get; private set; }


        public static Price FromDecimal(decimal value)
        {
            return new Price(value);
        }


        private Price(decimal value)
        {
            Value = value;
        }

        public static Price operator +(Price left, Price right) => new Price(left.Value + right.Value);
        public static Price operator -(Price left, Price right) => new Price(left.Value - right.Value);

        public override int ObjectGetHashCode() => Value.GetHashCode();

        public override bool ObjectIsEqual(Price otherObject) => Value == otherObject.Value;

        public static implicit operator decimal(Price price) => price.Value;
    }

}
