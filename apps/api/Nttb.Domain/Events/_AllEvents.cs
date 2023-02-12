namespace Nttb.Domain.Events;

public record EventMap(string Key, Type Type)
{
    public static readonly EventMap[] AllEvents = new[]
    {
        // Events are listed in the order they are expected to be used.
        
        // Before the game starts we first determine the players (in single games we likely already know this).
        new EventMap(SetTeam.TYPENAME, typeof(SetTeam)),
        
        // And after the coin flip they decide the play sides and the service order.
        new EventMap(SetOrderOfPlay.TYPENAME, typeof(SetOrderOfPlay)),
        
        // TODO: Then the clock for warming up starts, stops.
        
        // TODO: Starting a game
        // TODO: Completing a rally
        // TODO: Interrupting a rally
        // TODO: Fouls
        // TODO: Completing a game
        // TODO: Changing side
        
        // TODO: A few more.
    };
}