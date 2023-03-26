namespace Nttb.Domain;

/// <summary>
///     A timestamp that is used to synchronize the server and client.
/// </summary>
/// <remarks>
///     The server will send ServerTimestamp on regular intervals. As soon as a client receives this it should start
///     using that timestamp and reset the <see cref="ClientOffset" /> to zero. The client can continue to use the
///     old values.
/// </remarks>
/// <param name="ServerTimestamp">The version of the ServerTimestamp of the server.</param>
/// <param name="ClientOffset">The offset defined by the client that needs to be applied to that of the server</param>
public record Timestamp(
    ServerTimestamp ServerTimestamp,
    ClientTimeOffset ClientOffset
);