# Game

1. Event Driven
2. Replayable
3. Immutable

## Event Model

````
SetId = A unique id associated with the set being played
UserId = A unique id associated with the user
InstanceId = A unique id associated with the running application (aka the "instance", can have name)
IndexId = A number that is incremented for each event that this instance sends about this set.
SequenceId = "U" + UserId + "I" + InstanceId + "S" + SequenceID

TemporalState = The state of the game at the time of the event, used by other clients to 

EventBase = ABSTRACT {
    // required
    setId: SetId,
    id: SequenceId,
    prevId: SequenceId | NULL,
    signature: string,
    temporalState: TemporalState,
    
    // Optional, max 8k of data (or some other limtiation to prevent abuse)
    meta: any,
    
    // Diagnostic
    diagTimestamp: datetime,
}
````

## The temporal state

The following is an object that must always be provided with each event. This is so that the server doesn't need to provide it.

```
{ 
    players: { home: [], away: [] },
    gamesWon: { home: 0, away: 0 },
    gameScores: [
        // Best of 5
        { home: 0, away: 0, state: "homeWon", required: true },
        { home: 0, away: 0, state: "notStarted", required: true },
        { home: 0, away: 0, state: "notStarted", required: true },
        { home: 0, away: 0, state: "notStarted", required: false },
        { home: 0, away: 0, state: "notStarted", required: false },
    ],
    currentGameIndex: null, // or 0, 1, 2, 3, 4, 5, et cetera.
    initialServe: null,
    serveCounter: 0,
    server: null,
    receiver: null,
    cards: [],
    timers: [],
    constants: [],
    variables: [],
    winner: null,
}
```

## Setup events

```json
[
    { "type": "addPlayer", "payload": { "name": "John", "team": "home" } },
    { "type": "addPlayer", "payload": { "name": "Jane", "team": "home" } },
    { "type": "addPlayer", "payload": { "name": "Jack", "team": "away" } },
    { "type": "addPlayer", "payload": { "name": "Jill", "team": "away" } },
    { "type": "setSides", "payload": { "game": 0, "left": "home", "right": "away" } },
    { "type": "startTimer", "payload": { "name": "warmingup", "duration": 120 } },
]
```

## Playing

```json
[
    { "type": "stopTimer", "payload": { "name": "warmingup" } },
    { "type": "startGame", "payload": { "game": 0, "service": { "side": "home", "player": "John" } } },
    { "type": "givePoint", "payload": { "team": "away", "game": 0, "score": "0-1" } },
    { "type": "removePoint", "payload": { "team": "away", "game": 0, "score": "0-0" } },
    { "type": "givePoint", "payload": { "team": "home", "game": 0, "score": "1-0" } },
    // A few points later 
    { "type": "givePoint", "payload": { "team": "home", "game": 0, "score": "11-0" } },
    { "type": "endGame", "payload": { "game": 0, "winner": "home", "score": "11-0" } }, // Explicit end and explicit score due to out-of-order
    { "type": "startTimer", "payload": { "name": "break", "duration": 60 } },
    { "type": "stopTimer", "payload": { "name": "break" } },
    { "type": "setSides", "payload": { "game": 0, "left": "away", "right": "home" } },
    { "type": "startGame", "payload": { "game": 1, "service": { "side": "away", "player": "Jack" } } },
    // A few points later (timeout)
    { "type": "startTimeout", "payload": { "side": "home", "duration": 60 } },
    { "type": "endTimeout", "payload": { "side": "home" } },
    { "type": "halt", "meta": { "reason": "fight" } },                          // Mark the game as halted, because a game can be stopped for various reason
    { "type": "resume", "meta": { "reason": "timeout - home" } },               // Mark the game as resumed
    // Cards
    { "type": "card", "payload": { "side": "home", "player": "John", "color": "yellow" }, "meta": { "remarks": "Lack of fair play" } },
    // End of game
    { "type": "endGame", "payload": { "game": 3, "winner": "home", "setScore": "3-1", "gameScores": "11-0,11-0,11-0" } }, // Explicit end and explicit score due to out-of-order
    { "type": "endSet", "payload": { "winner": "home", "setScore": "3-1", "gameScore": "11-9,11-9,11-9" } }, // Explicit end of set
]
```

A few notes:
- Changes to the score will always provide the resulting score. This is to prevent the need to calculate the score on the other side.
- Only two keys are always required: `type` and `payload`. The `meta` key is optional and can be used to provide additional information.
  - Note: The values in `payload` can be required and optional. Also some values are considered temporary (for example the `score`)
- Scores are always written as `homeScore-awayScore` (e.g. `11-9`), when multiple game scores are listed, they are separated by a comma (e.g. `11-9,11-9,11-9`).
- Although a winner can be determined by the score, it is still possible to explicitly end a game or set and specify another winner. This is to allow for games with different some wierd rules. 
  - Example: Home is the winner when the sum of the score is even (so 11-9=20) while away is the winner when the sum of the score is odd (so 11-8=19).

In the above examples we miss the following information:
1. The time that the event was send (according to the client, but we will also add the server side time, the client time is used for diagnostics)
2. The instanceId that send the event. The instanceId is often the UserId of a user, but can be expanded to a more complex structure. This is to allow for users that are logged in on multiple devices and still need a way to seperate the information.
   > Example use case is that of tech-savy organizer that has multiple tablets on different tables and where the information needs to be seperated. 
3. The "InstanceId/SequenceNumber" of the prior event (based on the entire message including the previous checksum and including the cryptographic hash of the message)
4. A cryptographic signature which verifies the entire message.
   1. To calculate the signature, the client must have the private key of the public key that is used to verify the signature. Each client will upload a public key to the server. The server will NEVER have the private key.
   2. The signature is also used in the voting process to verify that the vote is valid and that specific version was approved.

The server will not discard messages, even if the previous message could not be found. However it will mark those messages (and messages based on those messages) as suspicious.
It will also request the client to send the entire history of messages again. If the client is unable to do so, the usedId will be marked as suspicious and might be blocked. 
If the client is able to send the entire history, the server will verify the checksums and signatures and the suspicious-mark will be removed.

## NOTES

1. https://www.nttb-scheidsrechters.nl/gele-kaarten/ at the bottom it lists the codes referee use to report a player. We could use the same codes.

## Multiple clients

Throughout the game, multiple clients can be connected to the server. As long as the clients are in "view" mode they will simply receive the events as they are send by the clients that are in "edit" mode.
At any time a client can switch from "view" to "edit" mode. When a client switches to "edit" mode they can send events to the server and ignore events of other clients that are in "edit" mode.
When a client switches from "edit" to "view" mode, they can choose to replay events of another client that is in "edit" mode. So that they are back in sync again (and can then switch to "edit" mode again).
When they switch to "edit" mode again, they are again given the option to replay events of another client that is in "edit" mode (including their own).

As such there might be multiple versions of the same games. The server will keep track of the versions and will allow the clients to choose which version they want to use.

The server can also only allow events of certain users to be shared (it will still receive all events, but it will not share the events to users other than the user that provided it).
This is called "official" mode. In this mode, the server will only share events of the users marked as "official" for that set to other users. 
This is mostly intended to be used when there is an official referee and the organizer prefers events of those users to be shared to other users.
There can be multiple users marked as "official" for a set.

Finally a user can send an "abandon" event. This will mark the events of that user as "abandoned" and the server will no longer list events leading up to that abandon branch. 
This is mostly intended to be used when two users notice that they are out of sync and one of them decides to abandon the their events in favor of the other user.
It also prevents those events from being replayable by other users since they are no longer listed.
However, this event is mostly organizational, another use can still continue from an abandoned branch. A user can not abandon an event from another instance.

### Client side features

The api is designed around the fact that multiple clients can be connected to the server, but the creation of events and how another client should interrupt those events is always handled by the client.

As such the following feature are possible:
1. Showing a sign when multiple clients are sending editing events
2. Shared editing: Accepting events from other clients as if they were their own
3. Fix up: Performing a change and then replay the events (for example when the wrong player is selected)
   1. Better is to use the opposite command (e.g.: send `removePlayer` followed up `addPlayer` instead of going back and branching).
   2. Keep in mind most temporal events (like `startGame`) can be send multiple times.

### Multiple first event

Due to the nature of the system, it is possible that multiple clients send the first event. This is not a problem, since we always assume that multiple versions of the same set are possible. 

## Signing

At the end of a match, the players need to sign-off on the outcome of the match. This is done by sending a "vote" event.
A vote can only be send about `endSet` events and thus will always refer to a specific state of the game. 
This way the user is guaranteed that their vote can't be manipulated by someone the fact. 
After all: This would require forging the signature of both the user that send the `endSet` and the user that send the `vote` event.

> NOTE: Since every set needs to be signed, it is a good idea for a client to have a feature to sign-off multiple sets at once.

In the event of a dispute it will also allow the user to create their own version of the truth and vote for that version.

The shortest version of set looks like this:
```json
[
   { "type": "addPlayer", "payload": { "name": "John", "team": "home" }, "signature": "V1S1", "basedOn": null },
   { "type": "addPlayer", "payload": { "name": "Jack", "team": "away" }, "signature": "V1S2", "basedOn": "V1S1" },
   { "type": "endSet", "payload": { "winner": "home", "score": "11-9,11-9,11-9" }, "signature": "V1S3", "basedOn": "V1S2" }
]
```

However in this case three users have created three different versions of the truth.
```json
[
   { "type": "addPlayer", "payload": { "name": "John", "team": "home" },                "signature": "V1S1", "basedOn": null   },
   { "type": "addPlayer", "payload": { "name": "Jack", "team": "away" },                "signature": "V1S2", "basedOn": "V1S1" },
   { "type": "endSet", "payload": { "winner": "home", "score": "11-9,11-9,11-9" },      "signature": "V1S3", "basedOn": "V1S2" },
  
   { "type": "addPlayer", "payload": { "name": "Jill", "team": "away" },                "signature": "V2S2", "basedOn": "V1S1" },
   { "type": "endSet", "payload": { "winner": "home", "score": "11-9,9-11,11-9,11-9" }, "signature": "V2S3", "basedOn": "V2S2" },
  
   { "type": "endSet", "payload": { "winner": "home", "score": "11-9,11-0,11-9" },      "signature": "V3S4", "basedOn": "V2S3" }
]
```

Now there are three different versions of the truth and thus the user should be presented with a choice to vote for one of the versions.

> **EXAMPLE**
> Due to a dispute, the following versions of the set are available, please vote for the version you agree with:
> 1. John vs Jack (signature: V1S3)
>    11-9,11-9,11-9
> 2. John vs Jill (signature: V2S3)
>    11-9,9-11,11-9,11-9
> 3. John vs Jack (signature: V3S4)
>     11-9,11-0,11-9

The advantage of this is so that organizers can later review the sets and see what happened. They can see something like this:

```json
{ 
   "//": "NOTE: This is a dummy representation of the data, the actual data will be more complex",
   "setId": "F1D8E355-67D4-4075-96B7-F5EEF47BE5A1",
   "stateAt": "1990-12-31T23:59:59.999Z",
   "voters": [
      { "name": "John", "role": "home-player", "forSignature": "V3S4" },
      { "name": "Jack", "role": "away-player", "forSignature": "V3S4" },
      { "name": "Jill", "role": "away-player", "forSignature": null }
   ]
}
```

These vote events are also send to the server. And thus the full event log might look something like this:
```json
[
   { "type": "addPlayer", "payload": { "name": "John", "team": "home" },                "signature": "V1S1", "basedOn": null   },
   { "type": "addPlayer", "payload": { "name": "Jack", "team": "away" },                "signature": "V1S2", "basedOn": "V1S1" },
   { "type": "endSet", "payload": { "winner": "home", "score": "11-9,11-9,11-9" },      "signature": "V1S3", "basedOn": "V1S2" },
   { "type": "addPlayer", "payload": { "name": "Jill", "team": "away" },                "signature": "V2S2", "basedOn": "V1S1" },
   { "type": "endSet", "payload": { "winner": "home", "score": "11-9,9-11,11-9,11-9" }, "signature": "V2S3", "basedOn": "V2S2" },
   { "type": "endSet", "payload": { "winner": "home", "score": "11-9,11-0,11-9" },      "signature": "V3S4", "basedOn": "V2S3" },

   { "user": "John", "type": "vote", "payload": { },        "signature": "voteJack", "basedOn": "V3S4" },
   
   { "user": "Jack", "type": "vote", "payload": { },        "signature": "voteJack", "basedOn": "V3S4" },
   
   { "user": "Jill", "type": "vote", "payload": { },                                                        "signature": "voteJill1", "basedOn": "V2S3" },
   { "user": "Jill", "type": "cancelVote", "payload": {}, "meta": {"remarks": "filled in the wrong game"},  "signature": "voteJill2", "basedOn": "voteJill1" },
   { "user": "Jill", "type": "abandon", "payload": {}, "meta": {"remarks": "removing the version"},         "signature": "voteJill3", "basedOn": "V2S3" }
]
```

And this explains why Jill shows up as a voter without giving a vote, Jill might have been playing a later game against John but had already entered the form.

To prevent multiple votes the server will reject multiple votes. A vote can only be given when that user has not voted or all the previous votes have been canceled.
In addition the server will also reject votes once the organizers have approved.

## Approved by the organizer

A set will be marked as "open" (everyone can edit), "official" (only officials and organizers can edit), "closed" (no one can edit). 
The organizer can then mark an endState as "approved" (the set is now official).

## A few notes:

- The entire system creates a dependency graph of the events. This allows multiple versions of the truth to exist. The organizer can then review the graph and see what happened.
- The organizer can choose to approve a different version of the truth, they can even alter it, but even if abusing their own power the system can still display it.
- The worst case scenario is when a user generates hundred different versions of the truth, however the voting system should make it easier to filter. 
- I'm thinking of putting the voting outside of the event-stream of the set. 

## TODO

1. Change ChecksumPrior to PriorSequenceId. 

CardColor:
- Opgooien batje en vangen => Geen kaart
- Opgooien batje en niet vangen => Geel
- Opgooien batje en niet vangen en batje kapot => Rood en disqwalificatie
