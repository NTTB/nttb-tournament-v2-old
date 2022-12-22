namespace Nttb.Domain.Common.Models;

public abstract class ValueObject: IEquatable<ValueObject>
{
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }
        return ReferenceEquals(left, null) || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !(EqualOperator(left, right));
    }

    public abstract IEnumerable<object> GetEqualityComponents();

    public bool Equals(ValueObject? obj){
        return Equals((object?)obj);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        var other = obj as ValueObject;
        if (other == null)
        {
            return false;
        }

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
}