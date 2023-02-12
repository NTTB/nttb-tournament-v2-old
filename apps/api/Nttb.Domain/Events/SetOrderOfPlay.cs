using Nttb.Domain.Player.ValueObjects;

namespace Nttb.Domain.Events;

/// <summary>
/// The event data of when the service is set
/// </summary>
public sealed class SetOrderOfPlay : ISetEventBody
{
    /// <summary>
    /// The public name of this event type (should be public so that we can identify the type of an event).
    /// </summary>
    public const string TYPENAME = "SetService";
    
    /// <summary>
    /// The type name of this event.
    /// </summary>
    public string Type => TYPENAME;
    
    /// <summary>
    /// Who starts side starts serving
    /// </summary>
    public required ParticipantId Server { get; init; }
    public required ParticipantId Receiver { get; init; }
}