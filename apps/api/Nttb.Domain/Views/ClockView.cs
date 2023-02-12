namespace Nttb.Domain.Set;

/// <summary>
///     A clock that can be started and stopped. It should be used to track time, but not as an alert. The
///     <see cref="MaxDuration" /> is provided to ensure that viewers know when to expect the timer should have been
///     stopped and <see cref="MaxUsage" /> can be used to inform viewers how many times a certain clock can be used.
///     The usage of a clock (under the ITTF rules) will imply that the game is paused. Going over the maximum duration
///     of amount of times is not limited on the server side.
/// </summary>
public class ClockView
{
    /// <summary>
    ///     The meaning of the key is determined by the rule engine. For example: 1 can be timeout.
    /// </summary>
    public required int Key { get; init; }

    /// <summary>
    ///     The name to be displayed to the viewers. We recommend the english technical name, the client can use the
    ///     <see cref="Key" /> to determine the localized name.
    /// </summary>
    public required string DisplayName { get; init; }

    /// <summary>
    ///     How long this clock is allowed to run. A medical timeout can be 10 minutes, while a normal timeout can be 1 minute.
    /// </summary>
    public required TimeSpan MaxDuration { get; init; }

    /// <summary>
    ///     How often this clock can be used. Normally a timeout is only allowed once.
    /// </summary>
    public required int MaxUsage { get; init; }

    /// <summary>
    ///     All recorded usages of the clock.
    /// </summary>
    public required IEnumerable<SetClockSpan> Usages { get; init; }
}