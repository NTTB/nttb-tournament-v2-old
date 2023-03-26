using Nttb.Domain.Old.RuleEngines;

namespace Nttb.Domain.Old.Views;

/// <summary>
///     Describes the set including the current score, clock states and the current state. It should have enough
///     information to fully determine the state of the game. Since the view is always captured between rally's it will
///     always describe the state of prior to the next rally. In the event the set is done it will describe it as if there
///     is still a point that needs to be played.
/// </summary>
public class SetView
{
    /// <summary>
    ///     The rule engine used for this set. The server defines the rule engine, but does not enforce it. It's up to the
    ///     clients to determine how the rules should be implemented. The server only passes along the information.
    /// </summary>
    public required RuleEngineId RuleEngineId { get; init; }

    /// <summary>
    ///     The home team
    /// </summary>
    public required SetTeam HomeTeam { get; init; }

    /// <summary>
    ///     The away team.
    /// </summary>
    public required SetTeam AwayTeam { get; init; }

    /// <summary>
    ///     The state of the set
    /// </summary>
    public required StatusOfSet Status { get; init; }

    /// <summary>
    ///     The amount of games that are won by either team.
    /// </summary>
    public required Score GamesWon { get; init; }

    /// <summary>
    ///     The latest view state of each game.
    /// </summary>
    public required IEnumerable<GameView> Games { get; init; }

    /// <summary>
    ///     The clocks in a set, associated with the home team.
    ///     NOTE: Under ITTF there are only two: Timeout and MedicalTimeout
    /// </summary>
    public required IEnumerable<CountDownClock> HomeClocks { get; init; }

    /// <summary>
    ///     The clocks in a set, associated with the away team.
    ///     NOTE: Under ITTF there are only two: Timeout and MedicalTimeout
    /// </summary>
    public required IEnumerable<CountDownClock> AwayClocks { get; init; }

    /// <summary>
    ///     The clocks in a set, associated with neither team.
    ///     NOTE: Under ITTF there can be a few, for example: Warming up, waiting for player, etc.
    /// </summary>
    public required IEnumerable<CountDownClock> SetClocks { get; init; }

    /// <summary>
    ///     Cards that participants have before the set and that are relevant for the match.
    /// </summary>
    public required IEnumerable<HistoricCardRecord> HistoricCards { get; init; }

    /// <summary>
    ///     Cards that participants were given during the set.
    /// </summary>
    public required IEnumerable<PlayingCardRecord> CardsDuring { get; init; }

    /// <summary>
    ///     A list of values that won't change throughout the set whose meaning and interpretation is determined by the
    ///     rule engine. For example the ITTF rule engine only has "BestOf"
    /// </summary>
    public required Dictionary<string, object> Constants { get; init; }

    /// <summary>
    ///     A list of values that can change throughout the set whose meaning and interpretation is determined by the
    ///     rule engine. The ITTF rule engine has one: "ExpeditePlay".
    /// </summary>
    public required Dictionary<string, object> Variables { get; init; }
}