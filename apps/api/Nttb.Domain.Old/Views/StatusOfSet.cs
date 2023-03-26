namespace Nttb.Domain.Old.Views;

/// <summary>A enum describing the state of a set</summary>
public enum StatusOfSet
{
    /// <summary>The set is not started yet</summary>
    NotStarted,

    /// <summary>
    ///     The set is in progress
    /// </summary>
    InProgress,

    /// <summary>
    ///     The set is halted by the referee until a later time and date.
    /// </summary>
    /// <remarks>
    ///     Not to be confused with <see cref="StatusOfGame" /> that is <see cref="StatusOfGame.Paused" /> since that describes
    ///     a temporary state. This is more for situations where the set can no longer be continued to play. For example when
    ///     the roof collapses.
    /// </remarks>
    Halted,

    /// <summary>The set is finished and home team is considered a winner</summary>
    HomeWon,

    /// <summary>The set is finished and away team is considered a winner</summary>
    AwayWon,

    /// <summary>The set is finished and home team is considered a winner by walk over</summary>
    HomeWalkOver,

    /// <summary>The set is finished and away team is considered a winner by walk over</summary>
    AwayWalkOver
}