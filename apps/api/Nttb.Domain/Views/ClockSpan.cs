namespace Nttb.Domain.Set;

/// <summary>
///     Describes when a clock started to run and when it was stopped.
/// </summary>
public class ClockSpan
{
    /// <summary>
    ///     When was the clock started (the time is always that of the author of the event)
    /// </summary>
    public required DateTime StartedAt { get; init; }

    /// <summary>
    ///     How long the clock ran (according to the author of the event). If missing the clock is running and needs
    ///     to be stopped.
    /// </summary>
    /// <remarks>
    ///     Since there is no "shared time" a clock started on client and stopped on another can be have different times.
    ///     However since this is part of the view state the stopping client can for example use the time when it received the
    ///     "start" to modify the <see cref="StartedAt" /> so that the duration makes sense.
    /// </remarks>
    public required TimeSpan? Duration { get; init; }
}