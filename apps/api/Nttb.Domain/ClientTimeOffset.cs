namespace Nttb.Domain;

/// <summary>
///     The amount of time passed according to the client.
/// </summary>
public record ClientTimeOffset(uint Milliseconds)
{
    public static ClientTimeOffset Zero => new(0);
}