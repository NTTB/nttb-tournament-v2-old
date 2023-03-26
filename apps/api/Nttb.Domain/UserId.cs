namespace Nttb.Domain;

public record UserId(Guid Value)
{
    public static UserId CreateUnique() => new(Guid.NewGuid());
}