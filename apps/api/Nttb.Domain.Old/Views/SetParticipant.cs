namespace Nttb.Domain.Old.Views;

/// <summary>
/// A participant in a set.
/// </summary>
public class SetParticipant
{
    /// <summary>
    /// The unique id of the participant. This id is used to identify the participant in the set.
    /// </summary>
    public required ParticipantId Id { get; init; }
    
    /// <summary>
    /// The name to display for the participant.
    /// </summary>
    public required string DisplayName { get; init; }
}