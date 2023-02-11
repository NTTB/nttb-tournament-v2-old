using Nttb.Domain.Game.ValueObjects;
using Nttb.Domain.Player.ValueObjects;
using Nttb.Domain.RuleEngine.ValueObjects;
using Nttb.Domain.Set.ValueObjects;

namespace Nttb.Domain.Set;

/// <summary>
///  Describes the current set including the current score, clock states and the current phase.  
/// </summary>
public class SetViewState
{
    // Information about the players and teams
    public required IEnumerable<SetViewPlayer> HomePlayers { get; init; }
    public required IEnumerable<SetViewPlayer> AwayPlayers { get; init; }
    public required string HomeDisplayName { get; init; }
    public required string AwayDisplayName { get; init; }
    
    // Information about the game
    public required Score GamesWon { get; init; }
    public required IEnumerable<GameViewState> Games { get; init; }
    
    // The clocks
    public required IEnumerable<Clock> HomeClocks { get; init; }
    public required IEnumerable<Clock> AwayClocks { get; init; }
    public required IEnumerable<Clock> SetClocks { get; init; }
    
    // Cards
    public required IEnumerable<PriorCardRecord> CardsBefore { get; init; }
    public required IEnumerable<PlayingCardRecord> CardsDuring { get; init; }
    
    // Rule engine
    public required RuleEngineId RuleEngineId { get; init; }
    public required Dictionary<string, object> Constants { get; init; }
    public required Dictionary<string, object> Variables { get; init; }
}

public class SetViewPlayer
{
    public required PlayerId Id { get; set; }
    public required string DisplayName { get; set; }
}

public class GameViewState
{
    public required Score Score { get; init; }
    public required GameState State { get; init; }
    public required PlayerId? InitialServer { get; init; }
    public required PlayerId? InitialReceiver { get; init; }
    
    public required PlayerId? CurrentServer { get; init; }
    public required PlayerId? CurrentReceiver { get; init; }
    
    public required IEnumerable<Clock> HomeClocks { get; init; }
    public required IEnumerable<Clock> AwayClocks { get; init; }
    public required IEnumerable<Clock> GameClocks { get; init; }
}

public class Clock
{
    // TODO: Maybe key should be something else since we have various for different purposes
    // TODO: Timeout = Amount for a timeout called, can be stopped earlier. ITTF rules: 1 minute
    // TODO: MedicalTimeout = Amount for a timeout called, can be stopped earlier. ITTF rules: 10 minutes
    // TODO: SwitchClock = Amount of time between games.
    // TODO: Although the expedite warning is more a trigger than a clock
    public required string Key { get; init; } 
    public required TimeSpan MaxDuration { get; init; }
    public required int MaxUsage { get; init; }
    public required IEnumerable<SetClockSpan> Usages { get; init; }
}

public class SetClockSpan
{
    public required DateTime StartedAt { get; init; }
    public required TimeSpan? Duration { get; init; }
}


public enum GameState
{
    NotStarted,
    Active,
    Paused,
    HomeWon,
    AwayWon,
    HomeWalkOver,
    AwayWalkOver,
}

public class PriorCardRecord
{
    public required PlayerId Player { get; init; }
    public required CardType Type { get; init; }
}

public class PlayingCardRecord
{
    public required PlayerId Player { get; init; }
    public required CardType Type { get; init; }
    public required DateTime GivenAt { get; init; }
    public required CardReason Reason { get; init; }
    public required string AdditionalDetails { get; init; }
}

// TODO: What is the reason for these enums?
// Code: 	01	- schoppen tegen de tafel of de omheining etc.
// Code: 	02	- gooien met het batje
// Code: 	03	- vloeken, schelden of het uiten van onwelvoeglijke taal
// Code: 	05	- wegschoppen of wegslaan van de bal
// Code: 	07	- niet op tijd terugkeren van de pauze tussen twee games of een time out (na waarschuwing)
// Code: 	08	- coachen tijdens het spel in woord en/of gebaar
// Code: 	10	- met vuist of bat op de tafel slaan
// Code: 	12	- het moedwillig verplaatsen of verbouwen van de afzetting
// Code: 	18	- met het bat op de grond of ander object slaan
// Code: 	20	- overige (nader te omschrijven)
public enum CardReason
{
    KickingEnvironment = 1,
    ThrowingOwnBat = 2,
    Swearing = 3,
    KickingAwayTheBall = 5,
    NotReturningOnTime = 7,
    Coaching = 8,
    HittingTable = 10,
    ModifyingEnvironment = 12,
    UsingBatToHitSomething = 18,
    Other = 20
}

// Opgooien batje en vangen => Geen kaart
// Opgooien batje en niet vangen => Geel
// Opgooien batje en niet vangen en batje kapot => Rood en disqwalificatie
public enum CardType
{
    Yellow,
    YellowRed,
    Red // Disqualifying a player, can include a reference to the disciplinary committee
}