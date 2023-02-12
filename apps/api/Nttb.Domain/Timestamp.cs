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

/// <summary>
///     A timestamp from the server send to the clients.
/// </summary>
/// <param name="Value">A 64 bit number that defines the date and time</param>
/// <remarks>
///     The server will send this on regular intervals (for example once every 5 minutes). Everytime the server sends a new
///     version the values are determined by the server. The server will always roll forward and should never roll back.
///     The server time will not accommodate for leap seconds, leap hours and so on.
///     It can be compared to <a href="https://en.wikipedia.org/wiki/Geocentric_Coordinate_Time">TCG</a> although "(UTC)
///     Coordinated Universal Time" is a more pragmatic approach.
///     The idea is that we can sum the value of the Server with the <see cref="ClientTimeOffset" /> and then map that
///     to an accurate value.
///     <list type="table">
///         <listheader>
///             <term>Range</term>
///             <term>BitLength</term>
///             <term>Name</term>
///             <term>Usage</term>
///         </listheader>
///         <item>
///             <description>0..12</description>
///             <description>12</description>
///             <description>Year</description>
///             <description>year (0-4095)</description>
///         </item>
///         <item>
///             <description>12..21</description>
///             <description>9</description>
///             <description>DayOfYear</description>
///             <description>day of the year (0-511). Assuming year is 1990 then 01-January-1900 is <c>0</c>  </description>
///         </item>
///         <item>
///             <description>21..22</description>
///             <description>1</description>
///             <description>MillisecondGuard</description>
///             <description>Always zero, acts as an extra guard</description>
///         </item>
///         <item>
///             <description>22..23</description>
///             <description>1</description>
///             <description>MillisecondOverflow</description>
///             <description>overflow of milliseconds (in the event <see cref="ClientTimeOffset"/> is added)</description>
///         </item>
///         <item>
///             <description>22..45</description>
///             <description>22</description>
///             <description>MillisecondsOfDay</description>
///             <description>milliseconds of the day since midnight (0-4194303), this allows a overflow of almost 2 days (45.9051 hours)</description>
///         </item>
///         <item>
///             <description>45..46</description>
///             <description>1</description>
///             <description>NoiseGuard</description>
///             <description>Always zero, acts as an extra guard for the overflow of noise</description>
///         </item>
///         <item>
///             <description>46..47</description>
///             <description>1</description>
///             <description>NoiseOverflow</description>
///             <description>When set, it will indicate that the value overflow </description>
///         </item>
///         <item>
///             <description>47..64</description>
///             <description>16</description>
///             <description>Noise</description>
///             <description>random value to ensure clients are not guessing the timestamp</description>
///         </item>
///     </list>
/// </remarks>
public record ServerTimestamp(ulong Value);

/// <summary>
///     The amount of time passed according to the client.
/// </summary>
/// <param name="Value">A 64 bit number that defines the offset.</param>
/// <remarks>
///     <list type="table">
///         <listheader>
///             <term>Range</term>
///             <term>BitLength</term>
///             <term>Name</term>
///             <term>Usage</term>
///         </listheader>
///         <item>
///             <description>0..21</description>
///             <description>21</description>
///             <description>AlwaysZero</description>
///             <description>This range is used by <see cref="ServerTimestamp"/> to determine year and day, but is unused for offsetting</description>
///         </item>
///         <item>
///             <description>21..22</description>
///             <description>1</description>
///             <description>MillisecondGuard</description>
///             <description>Always zero, acts as an extra guard. When set then everything is invalid</description>
///         </item>
///         <item>
///             <description>22..23</description>
///             <description>1</description>
///             <description>MillisecondOverflow</description>
///             <description>overflow of milliseconds (in the event <see cref="ServerTimestamp"/> is added)</description>
///         </item>
///         <item>
///             <description>22..45</description>
///             <description>22</description>
///             <description>MillisecondsOffset</description>
///             <description>Milliseconds to add to server offset, this allows a overflow of almost 2 days (45.9051 hours)</description>
///         </item>
///         <item>
///             <description>45..46</description>
///             <description>1</description>
///             <description>CorrectionGuard</description>
///             <description>Always zero, acts as an extra guard for correction guard</description>
///         </item>
///         <item>
///             <description>46..47</description>
///             <description>1</description>
///             <description>RoundTripOverflow</description>
///             <description>When set, it will indicate that the future overflow </description>
///         </item>
///         <item>
///             <description>47..64</description>
///             <description>16</description>
///             <description>RoundTripMs</description>
///             <description>The milliseconds that the client estimates the server send (comparable to ping-time)</description>
///         </item>
///     </list>
/// </remarks>
public record ClientTimeOffset(ulong Value);