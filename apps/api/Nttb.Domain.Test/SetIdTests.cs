namespace Nttb.Domain.Test;

public class SetIdTests
{
    [Test]
    public void CreateUnique_should_return_a_new_id()
    {
        var value = SetId.CreateUnique();
        Assert.That(value, Is.Not.Null);
    }
    
    [Test]
    public void CreateUnique_should_return_a_new_id_with_a_value()
    {
        var value = SetId.CreateUnique();
        Assert.That(value.Value, Is.InstanceOf<Guid>());
        Assert.That(value.Value, Is.Not.EqualTo(Guid.Empty));
    }
}