using Nttb.Domain.Common.Models;
using Nttb.Domain.Player.ValueObjects;

namespace Nttb.Domain.Player.Entities;

public class Player : Entity<PlayerId>
{
    // TODO: Decide what values we need to capture for a player.
    // EXAMPLES:
    // - Is a player unique in general?
    // - Is a player unique per tournament?
    // - Is a player unique per team?
    // - What if a player has multiple entries in a tournament?
    public Player(PlayerId id) : base(id)
    {
    }
}