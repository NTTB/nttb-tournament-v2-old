namespace Nttb.Domain.Views;

/// <summary>
///     Describes the status of a game.
/// </summary>
public enum StatusOfGame
{
    /// <summary>
    ///     The game has not yet started or is not tracked.
    /// </summary>
    NotStarted,

    /// <summary>
    ///     The game has started and is being played.
    /// </summary>
    Active,

    /// <summary>
    ///     The game has been paused for some reason. This can be due to a timeout but also due to the referee stopping the
    ///     game. Timeout is also considered a pause. The game is also paused when a outside ball enters the court or the ball
    ///     of the current court has left the court.
    /// </summary>
    /// <remarks>Not to be confused with a set that is <see cref="StatusOfSet.Halted" /></remarks>
    Paused,

    /// <summary>
    ///     The game is finished and the home team has won.
    /// </summary>
    HomeWon,

    /// <summary>
    ///     The game is finished and the away team has won.
    /// </summary>
    AwayWon,

    /// <summary>
    ///     The game is finished and the home team has won this game by walk over (which likely also means the set is won by
    ///     home-team)
    /// </summary>
    HomeWalkOver,

    /// <summary>
    ///     The game is finished and the away team has won this game by walk over (which likely also means the set is won by
    ///     away-team)
    /// </summary>
    AwayWalkOver
}