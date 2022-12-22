# SetVariableId

## Properties of SetVariableId

- `SetId`: `SetStateId` - The unique identifier of the set (since each set variable is always associated with a set).
- `Key`: `string` - A unique name within the set.

A few examples of keys:
- `GameDuration` - A `SetClockVariable` that keeps track of the duration of a game.
- `HomeTimeoutDuration` - A `SetClockVariable` that keeps track of the duration of a timeout for the home team.
- `ExpediteRuleInvoked` - A `SetBooleanVariable` that keeps track of whether the expedite rule has been invoked.

## Example of SetVariableId

```json5
{
  "setId": {
    // ...
  },
  "key": "GameDuration",
}
```