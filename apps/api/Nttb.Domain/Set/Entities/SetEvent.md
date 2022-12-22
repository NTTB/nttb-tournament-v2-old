# SetEvent

## Properties

- `Id` : `SetEventId` - The unique identifier of the event.

## SubTypes

- PlayerAssignedToSet - Can happen multiple times when a player is assigned to a set. Occurs outside of a match.
- OrderAndSidesDecided - Happens after a toss, but before warming up.
- ClockResumed
  - GameStarted
  - TimeoutFinished
- ClockHalted
  - GameFinished   
  - TimeoutStarted
  - MedicalTimeoutStarted   
  - SetStopped (abstract)
    - SetFinished - A winner is declared
    - SetAborted - No winner is declared
  - Handdoek
  - InteruptionOtherCourt (ball on the court, clapping, etc.)
- ScoreChanged
  - ~ScoreCorrected~ scrapped since we don't care about that
  
# After discussion

- Have seperate clocks for warmingup, timeout, medical timeout, between games.
- Hint: Focus on the type of clock that is running, not on the type of event that is happening.
  - The type of clock is important and MUST be noted.
- Allow attaching a comment to a **clock event**.

The type of clocks:
- HomeTimeoutClock (non repeating, max 1 minute)
- AwayTimeoutClock (non repeating, max 1 minute)
- HomeMedicalTimeoutClock (non repeating, max 10 minute)
- AwayMedicalTimeoutClock (non repeating, max 10 minute)
- WarmingUpClock (non repeating, max 2 minute)
- PlayClock (10 minute per game, but not when a player has reached more than 18 points, resets after each game)
  - Role: To determine when the expedite rule comes in to play.
  - In theory this can mean that a set of best-of 5 can take up more than 50 minutes without the expedite rule as each game takes 9:59 minutes while if the first game was over 10 minutes then it's likely the other games will reach the 10 minute mark as well (since a rally ends after 13 strokes).
- BetweenGamesClock (1 minute)

NOTE:

- ChangeSides is een term die gebruikt wordt in de laatste game om van kant te wisselen, niet gebruiken om wisselen van kant tussen de games.