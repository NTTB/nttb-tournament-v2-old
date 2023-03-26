namespace Nttb.Domain;

/// <summary>
/// The authentication session id. This value will only change when the user logs out.
/// If for example the user logs in on a different device, the session id will be different.
/// If the user turns the device off and on again, the session will be the same.
/// If the device loses connection with the internet and reconnects, the session will be the same.
/// </summary>
public record SessionId(Guid Value)
{
    public static SessionId CreateUnique() => new(Guid.NewGuid());
}