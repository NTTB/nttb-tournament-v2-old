namespace Nttb.Domain.Test;

public class ClientApplicationInfoTests
{
    [Test]
    public void Constructor()
    {
        var name = "NTTB App";
        var version = "Preview";
        var url = "https://www.nttb.nl";
        var sut = new ClientApplicationInfo(name, version, url);
        Assert.That(sut.Name, Is.EqualTo(name));
        Assert.That(sut.Version, Is.EqualTo(version));
        Assert.That(sut.Url, Is.EqualTo(url));
    }
}