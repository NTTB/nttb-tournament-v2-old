using Nttb.Domain.Views;

namespace Nttb.Domain.Events;

/// <summary>
/// The event data of when a team is set.
/// </summary>
public sealed class SetTeam : ISetEventBody
{
    /// <summary>
    /// The public name of this event type (should be public so that we can identify the type of an event).
    /// </summary>
    public const string TYPENAME = "SetTeam";
    
    /// <summary>
    /// The type name of this event.
    /// </summary>
    public string Type => TYPENAME;
    
    /// <summary>
    /// Information for which side?
    /// </summary>
    public required TeamSide TeamSide { get; init; }
    
    /// <summary>
    /// The team composition.
    /// </summary>
    public required Views.SetTeam Team { get; init; }
}