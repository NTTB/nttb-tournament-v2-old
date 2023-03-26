namespace Nttb.Domain.Test;

public class ServerTimestampTests
{
    [Test]
    public void Constructor()
    {
        var sut = new ServerTimestamp(1, 2, 3, 4);
        // Assert
        Assert.That(sut.Year, Is.EqualTo(1));
        Assert.That(sut.DayOfYear, Is.EqualTo(2));
        Assert.That(sut.MillisecondsOfDay, Is.EqualTo(3));
        Assert.That(sut.Noise, Is.EqualTo(4));
    }

    [Test]
    public void Zero()
    {
        var sut = ServerTimestamp.Zero;
        // Assert
        Assert.That(sut.Year, Is.EqualTo(0));
        Assert.That(sut.DayOfYear, Is.EqualTo(0));
        Assert.That(sut.MillisecondsOfDay, Is.EqualTo(0));
        Assert.That(sut.Noise, Is.EqualTo(0));
    }
}