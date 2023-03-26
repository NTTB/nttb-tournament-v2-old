namespace Nttb.Domain.Test;

public class AuthorTests
{
    [Test]
    public void Constructor()
    {
        var userId = UserId.CreateUnique();
        var sessionId = SessionId.CreateUnique();
        var displayName = "Wouter";
        var sut = new Author(userId, sessionId, displayName, null, null);
        Assert.That(sut.UserId, Is.EqualTo(userId));
        Assert.That(sut.SessionId, Is.EqualTo(sessionId));
        Assert.That(sut.DisplayName, Is.EqualTo(displayName));
        Assert.That(sut.DeviceName, Is.Null);
        Assert.That(sut.ClientApplicationInfo, Is.Null);
    }
    
    
    [Test]
    public void Constructor_WithDeviceNameAndClientAppInfo()
    {
        var userId = UserId.CreateUnique();
        var sessionId = SessionId.CreateUnique();
        var displayName = "Wouter";
        var deviceName = "Scoreboard Table 12";
        var clientApplicationInfo = new ClientApplicationInfo("NTTB App", "Preview", "https://www.nttb.nl");
        var sut = new Author(userId, sessionId, displayName, deviceName, clientApplicationInfo);
        Assert.That(sut.UserId, Is.EqualTo(userId));
        Assert.That(sut.SessionId, Is.EqualTo(sessionId));
        Assert.That(sut.DisplayName, Is.EqualTo(displayName));
        Assert.That(sut.DeviceName, Is.EqualTo(deviceName));
        Assert.That(sut.ClientApplicationInfo, Is.EqualTo(clientApplicationInfo));
    }
}