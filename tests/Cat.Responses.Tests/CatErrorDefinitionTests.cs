namespace Cat.Responses.Tests;

[TestFixture]
public class CatErrorDefinitionTests
{
    private static readonly CatErrorDefinition Definition =
        CatErrorDefinition.Create("T-100", "Product {name} is missing");

    [Test]
    public void Create_KeepsTheCodeAndTheMessage()
    {
        Assert.That(Definition.Code, Is.EqualTo("T-100"));
        Assert.That(Definition.Message, Is.EqualTo("Product {name} is missing"));
    }

    [Test]
    public void CreateCatError_UsesTheCodeTheMessageAndTheArguments()
    {
        var error = Definition.CreateCatError("Chair");

        Assert.That(error.Code, Is.EqualTo("T-100"));
        Assert.That(error.Message, Is.EqualTo("Product {name} is missing"));
        Assert.That(error.Arguments, Is.EqualTo(new object?[] { "Chair" }));
    }

    [Test]
    public void CreateCatError_WithoutArguments_HasNoArguments()
    {
        var error = Definition.CreateCatError();

        Assert.That(error.Arguments, Is.Empty);
    }

    [Test]
    public void GeneralDefinitions_HaveStableCodes()
    {
        Assert.That(CatGeneralErrorDefinitions.Unknown.Code, Is.EqualTo("CAT-GEN-1000"));
        Assert.That(CatGeneralErrorDefinitions.UnexpectedResponse.Code, Is.EqualTo("CAT-GEN-1001"));
        Assert.That(CatGeneralErrorDefinitions.ResourceNotFound.Code, Is.EqualTo("CAT-GEN-1002"));
    }

    [Test]
    public void GeneralDefinitions_HaveTheirMessageTemplates()
    {
        Assert.That(CatGeneralErrorDefinitions.Unknown.Message, Is.EqualTo("An unknown error occurred."));
        Assert.That(CatGeneralErrorDefinitions.UnexpectedResponse.Message, Is.EqualTo("An unexpected response was returned. ({Service})"));
        Assert.That(CatGeneralErrorDefinitions.ResourceNotFound.Message, Is.EqualTo("The requested {ResourceName} with id {ResourceId} was not found."));
    }
}
