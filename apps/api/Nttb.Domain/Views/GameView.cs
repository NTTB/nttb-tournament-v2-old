namespace Nttb.Domain.Views;

/// <summary>
/// A view of a game in a set.
/// </summary>
public class GameView
{
    /// <summary>
    ///     The score in the game
    /// </summary>
    public required Score Score { get; init; }

    /// <summary>
    ///     The state of the game
    /// </summary>
    public required StatusOfGame Status { get; init; }

    /// <summary>
    ///     The first player to serve in the game
    /// </summary>
    public required ParticipantId? InitialServer { get; init; }

    /// <summary>
    ///     The first player to receive in the game (required for doubles)
    /// </summary>
    public required ParticipantId? InitialReceiver { get; init; }

    /// <summary>
    ///     The player that should serve in the game.
    ///     NOTE: All view states capture the game when there is no rally being played, therefore it always describe the next
    ///     player to serve.
    /// </summary>
    public required ParticipantId? CurrentServer { get; init; }

    /// <summary>
    ///     The player that should receive in the game (required for doubles)
    ///     NOTE: All view states capture the game when there is no rally being played, therefore it always describe the next
    ///     player to receive.
    /// </summary>
    public required ParticipantId? CurrentReceiver { get; init; }

    /// <summary>
    ///     Clocks associated with the home team.
    ///     NOTE: Under ITTF circumstances there is no clock associated with the home team.
    /// </summary>
    public required IEnumerable<CountDownClock> HomeClocks { get; init; }

    /// <summary>
    ///     Clocks associated with the away team.
    ///     NOTE: Under ITTF circumstances there is no clock associated with the home team.
    /// </summary>
    public required IEnumerable<CountDownClock> AwayClocks { get; init; }

    /// <summary>
    ///     Clocks associated with neither the home or away team.
    ///     NOTE: Under ITTF circumstances there is only one clock associated with the game and that is the "prepare-game"
    ///     clock.
    /// </summary>
    public required IEnumerable<CountDownClock> GameClocks { get; init; }
}