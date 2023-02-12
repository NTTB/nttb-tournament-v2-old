namespace Nttb.Domain.Events;

/// <summary>
///     Sets the order of play
/// </summary>
public sealed class SetOrderOfPlay : ISetEventBody
{
    /// <summary>
    ///     The public name of this event type (should be public so that we can identify the type of an event).
    /// </summary>
    public const string TYPENAME = "SetOrderOfPlay";

    /// <summary>
    ///     The first server
    /// </summary>
    public required ParticipantId Server { get; init; }

    /// <summary>
    ///     The first receiver (required for doubles)
    /// </summary>
    public required ParticipantId Receiver { get; init; }

    /// <summary>
    ///     The side that the home team should be at.
    /// </summary>
    public required PlaySide HomeSide { get; init; }

    /// <summary>
    ///     The type name of this event.
    /// </summary>
    public string Type => TYPENAME;
}