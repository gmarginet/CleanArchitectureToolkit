namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ItemNameErrorDefinitionsTests
{
    [Test]
    public void NotFound_ShouldUseThePrefixOfTheArea()
    {
        Assert.That(ItemNameErrorDefinitions.NotFound.Code, Does.StartWith("ERROR_PREFIX-"));
    }
}
