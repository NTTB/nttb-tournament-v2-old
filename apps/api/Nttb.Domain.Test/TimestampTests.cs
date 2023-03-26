namespace Nttb.Domain.Test;

public class TimestampTests
{
    [Test]
    public void Constructor()
    {
        var serverTimestamp = new ServerTimestamp(1, 2, 3, 4);
        var clientTimeOffset = new ClientTimeOffset(5);
        var sut = new Timestamp(serverTimestamp, clientTimeOffset);
        // Assert
        Assert.That(sut.ServerTimestamp, Is.EqualTo(serverTimestamp));
        Assert.That(sut.ClientOffset, Is.EqualTo(clientTimeOffset));
    }
}