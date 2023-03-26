using Nttb.Domain.Old.Events;
using Nttb.Domain.Old.Views;

namespace Nttb.Domain.Old;

/// <summary>
///     An event that occurred in a set.
/// </summary>
/// <param name="Header">The header of the event, containing the id, the set id, the previous event id and the author id.</param>
/// <param name="Body">The body of the event, containing the type and the payload data.</param>
/// <param name="SetView">The state of the set after this event.</param>
/// <param name="Signature">
///     Proof that the header and body this event originated from the author using private-public key cryptography and are
///     not tempered with.
/// </param>
public record SetEvent(
    SetEventHeader Header, 
    ISetEventBody Body, // Contains the change to the set.  ( "home score +1")
    SetView SetView, // Shows the state of the set after this event. (Waarde is nu "7-11")
    SetEventSignature Signature);