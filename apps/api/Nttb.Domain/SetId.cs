namespace Nttb.Domain;

public record SetId(Guid Value)
{
    public static SetId CreateUnique()
    {
        return new SetId(Guid.NewGuid());
    }
}

public record SetCommitId(Guid Value)
{
    public static SetCommitId CreateUnique()
    {
        return new SetCommitId(Guid.NewGuid());
    }
}