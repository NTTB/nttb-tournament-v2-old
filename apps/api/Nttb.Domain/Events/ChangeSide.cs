
namespace Nttb.Domain.Events;

public sealed class ChangeSide : ISetEventBody
{
    /// <summary>
    /// The public name of this event type (should be public so that we can identify the type of an event).
    /// </summary>
    public const string TYPENAME = "ChangeSide";
    
    /// <summary>
    /// The type name of this event.
    /// </summary>
    public string Type => TYPENAME;
    
    /// <summary>
    /// The location that the home side should be at.
    /// </summary>
    public required PlaySide Home { get; init; }
}