using Domain.Abstracts.ValueObjects;

namespace Domain.Shared.ValueObjects
{
    public class Title : ValueObject<Title>
    {
        public string Value { get; private set; }


        public static Title FromString(string value)
        {

            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Title));

            return new Title(value);
        }


        private Title(string value)
        {
            Value = value;
        }

        public override int ObjectGetHashCode() => Value.GetHashCode();

        public override bool ObjectIsEqual(Title otherObject) => Value == otherObject.Value;

        public static implicit operator string(Title value) => value.Value;
    }

}
