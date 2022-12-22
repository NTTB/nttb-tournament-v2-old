# SetVariable<T>

The goal of SetVariables is to keep track of variables that are associated with a set so that it can be used by the rule engine.

Variables once created will continue to exist, this follows the [event-sourcing pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/event-sourcing).

## ITTF rule engine variables

**NOTE**: The ITTF rule engine requires the following variables:
- `Expidite` : `SetVariable<bool>` - Track whether the expedite rules has been invoked.
- `GameClock` : `SetVariable<ClockState>` - Track the duration of the current game and whether or not the expedite rule must be invoked.
- `WarmingupClock` : `SetVariable<ClockState>` - Track the time for warming up
- `HomeTimeoutClock` : `SetVariable<ClockState>` - Track the time for home timeout, when duration is zero no timeout was requested.
- `AwayTimeoutClock` : `SetVariable<ClockState>` - Track the time for away timeout, when duration is zero no timeout was requested.
- `HomeMedicalTimeoutClock` : `SetVariable<ClockState>` - Track the time for home medical timeout, when duration is zero no timeout was requested.
- `AwayMedicalTimeoutClock` : `SetVariable<ClockState>` - Track the time for away medical timeout, when duration is zero no timeout was requested.

## Types of SetVariable<T>
### SetVariable<ClockState>

Within a set there are multiple clocks that can be running at the same time.
For example: a clock for the duration of a game, a clock for the duration of a timeout, a clock for the duration of a medical timeout, etc.

A clock consist out of a series of events.

- Clocks can be reset. For example, the clock for the duration of a game is reset after each game.
- Clocks can be paused. For example, the clock for the duration of a game is paused when a timeout is invoked.
- Clocks can be resumed. For example, the clock for the duration of a game is resumed when a timeout is finished.

This means that certain clocks (like the one for warmup) will have no value after the warmup is finished, but still continue to exist.
The same applies for the clock for the duration of a game, its primary function under the ITTF rules is to determine when the expedite rules must have been invoked.

Using the events we can calculate the duration of the clock.

### SetVariable<Boolean>

The goal of SetBooleanVariable is to keep track of a boolean variable so that it can be used by the rule engine.
The last state is the current state.

Example of a boolean variable is the `ExpediteRuleInvoked` variable.

## Properties of SetVariable<T>

- `Id` : `SetVariableId` - The unique identifier of the clock state.
- `Events` : `SetVariableChangedEvent<T>[]` - The changes of the variable

## Example of SetVariable<T>

```json5
{
  "id": {
    "setId": { /* ... */ },
    "key": "ExpediteRuleInvoked",
  },
  "events": [
    {
      "on": "2021-09-01T12:00:00Z",
      "value": { /* ... */ }
    },
    {
      "on": "2021-09-01T12:00:00Z",
      "value": { /* ... */ }
    }
  ]
}
```