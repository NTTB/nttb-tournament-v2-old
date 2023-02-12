namespace Nttb.Domain;

/// <summary>
///     Contains the score of a game.
/// </summary>
/// <param name="Home">The score of the home team.</param>
/// <param name="Away">The score of the away team.</param>
public record Score(int Home, int Away);