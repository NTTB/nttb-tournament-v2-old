# Game

Represents a game.

## Properties

- Id : `Guid` - The unique identifier of the game.
- Score : `Score` - The score of the game
- InitialServer : `PlayerId` - The player who is first to serve in this game.
- InitialReceiver : `PlayerId` - The player who is first to receive in this game.

## Examples

```json
{
  "id": { "value": "00000000-0000-0000-0000-000000000000" },
  "score": { "home": 1, "away": 2 },
  "initialServer": { "value": "00000000-0000-0000-0000-000000000000" },
  "initialReceiver": { "value": "00000000-0000-0000-0000-000000000000" }
}
```