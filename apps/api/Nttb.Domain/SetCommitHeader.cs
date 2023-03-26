namespace Nttb.Domain;

public record SetCommitHeader(
    SetCommitId CommitId,
    SetId SetId,
    SetCommitId? PreviousCommitId,
    Author Author,
    Timestamp CreatedOn);