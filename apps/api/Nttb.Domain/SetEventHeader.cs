namespace Nttb.Domain;

/// <summary>
///     The header of an event.
/// </summary>
/// <param name="Id">A value that can be used by others to reference to this event.</param>
/// <param name="SetId">A value that references the set</param>
/// <param name="PreviousEventId">The previous event in the set?</param>
/// <param name="Author">The author of this event</param>
/// <param name="AuthorTime">The local time according to the author</param>
public record SetEventHeader(
    SetEventId Id,
    SetId SetId,
    SetEventId PreviousEventId,
    Author Author,
    DateTime AuthorTime
);