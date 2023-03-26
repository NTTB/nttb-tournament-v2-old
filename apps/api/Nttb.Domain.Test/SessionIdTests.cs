namespace Nttb.Domain.Test;

public class SessionIdTests
{
    [Test]
    public void Constructor()
    {
        var newGuid = Guid.NewGuid();
        var sut = new SessionId(newGuid);
        Assert.That(sut.Value, Is.EqualTo(newGuid));
    }
    
    [Test]
    public void CreateUnique_should_return_a_new_id_with_a_value()
    {
        var sut = SessionId.CreateUnique();
        Assert.That(sut.Value, Is.InstanceOf<Guid>());
        Assert.That(sut.Value, Is.Not.EqualTo(Guid.Empty));
    }
}