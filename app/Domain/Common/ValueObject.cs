namespace GenderDebate.Domain.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object?> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj is not ValueObject other || other.GetType() != GetType())
                return false;

            using var thisValues = GetEqualityComponents().GetEnumerator();
            using var otherValues = other.GetEqualityComponents().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (thisValues.Current is null ^ otherValues.Current is null)
                    return false;

                if (thisValues.Current is not null &&
                    !thisValues.Current.Equals(otherValues.Current))
                    return false;
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                foreach (var obj in GetEqualityComponents())
                {
                    hash = hash * 23 + (obj?.GetHashCode() ?? 0);
                }

                return hash;
            }
        }

        public static bool operator ==(ValueObject? a, ValueObject? b)
            => a is null && b is null || a is not null && a.Equals(b);

        public static bool operator !=(ValueObject? a, ValueObject? b)
            => !(a == b);
    }
}
