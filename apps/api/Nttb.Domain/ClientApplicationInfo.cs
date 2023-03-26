namespace Nttb.Domain;

/// <summary>
/// Information about the client application.
/// </summary>
/// <param name="Name">Name of the application</param>
/// <param name="Version">Version number (not required, can be null)</param>
/// <param name="Url">The url for more information</param>
public record ClientApplicationInfo(string Name, string? Version, string? Url);