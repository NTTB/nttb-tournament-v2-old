namespace Nttb.Domain.Test;

public class SetCommitHeaderTests
{
    [Test]
    public void Constructor()
    {
        var commitId = SetCommitId.CreateUnique();
        var previousCommitId = SetCommitId.CreateUnique();
        var setId = SetId.CreateUnique();
        var createdOn = new Timestamp(ServerTimestamp.Zero, ClientTimeOffset.Zero);
        var author = new Author(UserId.CreateUnique(), SessionId.CreateUnique(), "Wouter", null, null);

        // Act
        var setEvent = new SetCommitHeader(
            commitId, setId,
            previousCommitId,
            author,
            createdOn
        );

        // Assert
        Assert.That(setEvent.CommitId, Is.EqualTo(commitId));
        Assert.That(setEvent.PreviousCommitId, Is.EqualTo(previousCommitId));
        Assert.That(setEvent.SetId, Is.EqualTo(setId));
        Assert.That(setEvent.Author, Is.EqualTo(author));
        Assert.That(setEvent.CreatedOn, Is.EqualTo(createdOn));
    }
}