﻿namespace Nttb.Domain.Test;

public class SetCommitIdTests
{
    [Test]
    public void CreateUnique_should_return_a_new_id()
    {
        var value = SetCommitId.CreateUnique();
        Assert.That(value, Is.Not.Null);
    }

    [Test]
    public void CreateUnique_should_return_a_new_id_with_a_value()
    {
        var value = SetCommitId.CreateUnique();
        Assert.That(value.Value, Is.InstanceOf<Guid>());
        Assert.That(value.Value, Is.Not.EqualTo(Guid.Empty));
    }
}