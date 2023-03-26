namespace Nttb.Domain.Test;

public class SetCommitTests
{
    [Test]
    public void Constructor()
    {
        var header = new SetCommitHeader(
            SetCommitId.CreateUnique(), 
            SetId.CreateUnique(), 
            null,
            new Author(UserId.CreateUnique(), SessionId.CreateUnique(), "Wouter", null, null),
            new Timestamp(ServerTimestamp.Zero, ClientTimeOffset.Zero)
        );
        
        var sut = new SetCommit(header);
        
        Assert.That(sut.Header, Is.EqualTo(header));
    }
}