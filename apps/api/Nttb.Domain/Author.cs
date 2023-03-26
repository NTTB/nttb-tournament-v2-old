namespace Nttb.Domain;

/// <summary>
/// Describes the author of a message.
/// </summary>
/// <param name="UserId">The id of the user</param>
/// <param name="SessionId">The id of the session</param>
/// <param name="DisplayName">How the author should be displayed to others</param>
/// <param name="DeviceName">The name of the device (optional, the user can have multiple devices. For example when having multiple scoreboards)</param>
/// <param name="ClientApplicationInfo">Information about the application of the client (for debugging but also so that different app builds know each other)</param>
public record Author(UserId UserId,
    SessionId SessionId,
    string DisplayName, 
    string? DeviceName, 
    ClientApplicationInfo? ClientApplicationInfo
    );