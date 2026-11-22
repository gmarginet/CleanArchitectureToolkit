namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ServiceShortErrorDefinitionsTests
{
    [Test]
    public void ExampleNotFound_ShouldUseThePrefixOfTheService()
    {
        Assert.That(ServiceShortErrorDefinitions.ExampleNotFound.Code, Does.StartWith("SVC-EXA-"));
    }
}
