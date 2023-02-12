using Nttb.Domain.Set;

namespace Nttb.Domain.Views;

/// <summary>
/// Describes a team in a set.
/// </summary>
public class SetTeam
{
    /// <summary>
    /// The name that should be displayed with this team.
    /// </summary>
    public required string DisplayName { get; init; }
    
    /// <summary>
    /// The players in this team.
    /// </summary>
    public required SetParticipant[] Players { get; init; }
    
    /// <summary>
    /// Coaches and other non-players. 
    /// </summary>
    public required SetParticipant[] NonPlayers { get; init; }
}