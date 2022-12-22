using Nttb.Domain.Common.Models;
using Nttb.Domain.Game.ValueObjects;
using Nttb.Domain.Player.ValueObjects;

namespace Nttb.Domain.Game.Entities;

/// <summary>
///     A game in table tennis.
/// </summary>
public class Game : Entity<GameId>
{
    public Score Score { get; }

    /// <summary>
    ///     The initial server (required for single and double games)
    /// </summary>
    public PlayerId InitialServer { get; }

    /// <summary>
    ///     The initial receiver
    /// </summary>
    /// <remarks>Required for double games, to determine the serve order, however we require it for all games for simplicity.</remarks>
    public PlayerId InitialReceiver { get; }

    public Game(GameId id) : base(id)
    {
    }
}