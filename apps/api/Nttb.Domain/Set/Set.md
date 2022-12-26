# Set

Describes the state of a table tennis set. It *only* contains variables that all table tennis sets have in common.
A set will contain all the variables to determine the current state.

## Properties

- `Id` : `SetId` - The unique identifier of the set.
- `phaseId`: `PhaseId` - The unique identifier of the phase that this set is played.
- `RuleEngineId` : `RuleEngineId` - The id of the rule engine that must be used. The rule engine is a state machine.
- `Constants` : `Dictionary<string, object>` - The constants that are used by the rule engine but can also be displayed.
  Constants are values that will not change once a set starts.
- `HomePlayers` : `PlayerId[]` - The players of the home team.
- `AwayPlayers` : `PlayerId[]` - The players of the away team.
- `InitialServer` : `PlayerId` - The player who is first to serve in this set.
- `InitialReceiver` : `PlayerId` - The player who is first to receive in this set.
- `Games` : `Game[]` - The games of the set.
- `Variables` : `SetVariable[]` - The variables that are used by the rule engine.

### ITTF Constants

The following constants are used by the ITTF rule engine and must be set:

- `bestOf` : `int` - The number of games that must be won to win the set (e.g. 3, 5, 7).
- `scoreVersion` : `int` - The score that must be reached to win a game (default: 11, the only other allowed value is
  21).
  - This also determines the rotation of the server and receiver, 11=2 serves, 21=5 serves.
  
[//]: # (The `ScoreVersion` is only added since some tournaments use a different scoring version and we don't want a custom rule engine for that.)

## Example

```json5
{
  "id": { /* ... */ },
  "phaseId": { /* ... */ },
  "ruleEngineId": { "value": "00000000-0000-0000-0000-000000000000" },
  "constants": {
    "bestOf": 3,
    "scoreVersion": 11
  },
  "homePlayers": [
    { "value": "00000000-0000-0000-0000-000000000000" },
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "awayPlayers": [
    { "value": "00000000-0000-0000-0000-000000000000" },
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "initialServer": { "value": "00000000-0000-0000-0000-000000000000" },
  "initialReceiver": { "value": "00000000-0000-0000-0000-000000000000" },
  "games": [
    {
      "id": { "value": "00000000-0000-0000-0000-000000000000" },
      "setId": { "value": "00000000-0000-0000-0000-000000000000" },
      "score": {
        "home": 1,
        "away": 2
      },
      "initialServer": { "value": "00000000-0000-0000-0000-000000000000" },
      "initialReceiver": { "value": "00000000-0000-0000-0000-000000000000" }
    }
  ],
  "variables": [
    {
      "id": {
        "setId": { /* ... */ },
        "key": "GameDuration"
      },
      "events": []
    }
  ]
}
```

## TODO

- Nadenken over of de key van een SetId uit meerdere onderdelen waardes staan:
    - OrganizerId ("NTTB")
    - MatchId ("NK2022 Licentie-E")
    - PoolId/PhaseId ("Man Halve Finale")
    - SetId ("Wedstrijd 1")
- Mogelijk ook de GameId zo structureren, eventueel met volgnummers

## Some rules about IDs since I keep forgetting them

- They exist to uniquely identify an object.
- They are immutable.
- They are used to identify an object in a database.
- They are used to identify an object in a message.
- They should be simple (preferably a single GUID).
- They should NOT be composed of multiple values (e.g. a match id should not be composed of a tournament id and a match number).