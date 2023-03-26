namespace Nttb.Domain;

/// <summary>
/// Describes an timestamp that is used to synchronized between the server and client.
/// </summary>
/// <param name="Year"></param>
/// <param name="DayOfYear"></param>
/// <param name="MillisecondsOfDay"></param>
/// <param name="Noise">Prevents clients from guessing</param>
public record ServerTimestamp(ushort Year, ushort DayOfYear, uint MillisecondsOfDay, ushort Noise)
{
    public static ServerTimestamp Zero => new(0, 0, 0, 0);
}