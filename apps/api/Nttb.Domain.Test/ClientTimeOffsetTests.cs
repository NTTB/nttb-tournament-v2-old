namespace Nttb.Domain.Test;

public class ClientTimeOffsetTests
{
    [Test]
    public void Constructor()
    {
        var sut = new ClientTimeOffset(1);
        // Assert
        Assert.That(sut.Milliseconds, Is.EqualTo(1));
    }

    [Test]
    public void Zero()
    {
        var sut = ClientTimeOffset.Zero;
        // Assert
        Assert.That(sut.Milliseconds, Is.EqualTo(0));
    }
}