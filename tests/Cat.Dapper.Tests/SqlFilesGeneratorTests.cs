using System.Collections.Immutable;
using Cat.Dapper.SqlFiles;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace Cat.Dapper.Tests;

[TestFixture]
public class SqlFilesGeneratorTests
{
    private const string Folder = "/app/Handlers";

    private static readonly string HandlerSource = """
        namespace Shop.Orders;

        public partial class OrderOverviewQueryHandler
        {
            public string Read() => Sql;
        }
        """;

    [Test]
    public void SqlFile_NextToThePartialHandler_CreatesTheSqlConstant()
    {
        var result = Run(
            [(Folder + "/OrderOverviewQueryHandler.cs", HandlerSource)],
            [(Folder + "/OrderOverviewQueryHandler.sql", "SELECT \"Id\" FROM Orders")]);

        Assert.Multiple(() =>
        {
            Assert.That(result.GeneratorDiagnostics, Is.Empty);
            Assert.That(result.GeneratedTrees, Has.Length.EqualTo(1));
            Assert.That(result.GeneratedTrees[0].ToString(), Does.Contain("private const string Sql = @\"SELECT \"\"Id\"\" FROM Orders\";"));
            Assert.That(result.GeneratedTrees[0].ToString(), Does.Contain("namespace Shop.Orders"));
            Assert.That(result.OutputDiagnostics.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);
        });
    }

    [Test]
    public void SqlFile_WithASuffix_CreatesAConstantWithThatName()
    {
        var result = Run(
            [(Folder + "/OrderOverviewQueryHandler.cs", HandlerSource)],
            [(Folder + "/OrderOverviewQueryHandler.sql", "SELECT 1"), (Folder + "/OrderOverviewQueryHandler.Count.sql", "SELECT COUNT(*)")]);

        var generated = string.Join("\n", result.GeneratedTrees.Select(t => t.ToString()));
        Assert.Multiple(() =>
        {
            Assert.That(generated, Does.Contain("const string Sql ="));
            Assert.That(generated, Does.Contain("const string CountSql ="));
        });
    }

    [Test]
    public void SameFileNameInTwoFolders_EachBelongsToTheClassOfItsOwnFolder()
    {
        var result = Run(
            [
                (Folder + "/OrderOverviewQueryHandler.cs", HandlerSource),
                ("/app/Other/OrderOverviewQueryHandler.cs", HandlerSource.Replace("namespace Shop.Orders", "namespace Shop.Other"))
            ],
            [(Folder + "/OrderOverviewQueryHandler.sql", "SELECT 1"), ("/app/Other/OrderOverviewQueryHandler.sql", "SELECT 2")]);

        Assert.Multiple(() =>
        {
            Assert.That(result.GeneratorDiagnostics, Is.Empty);
            Assert.That(result.GeneratedTrees, Has.Length.EqualTo(2));
        });
    }

    [Test]
    public void SqlFile_WithoutAMatchingClassInItsFolder_IsAnErrorThatNamesTheFile()
    {
        var result = Run(
            [("/app/Elsewhere/OrderOverviewQueryHandler.cs", HandlerSource)],
            [(Folder + "/OrderOverviewQueryHandler.sql", "SELECT 1")]);

        AssertSingleError(result, "CATSQL001", "OrderOverviewQueryHandler.sql");
    }

    [Test]
    public void SqlFile_ForAClassThatIsNotPartial_IsAnError()
    {
        var result = Run(
            [(Folder + "/OrderOverviewQueryHandler.cs", HandlerSource.Replace("partial ", string.Empty).Replace("=> Sql", "=> \"\""))],
            [(Folder + "/OrderOverviewQueryHandler.sql", "SELECT 1")]);

        AssertSingleError(result, "CATSQL002", "OrderOverviewQueryHandler.sql");
    }

    [TestCase("OrderOverviewQueryHandler.Count.Extra.sql")]
    [TestCase("OrderOverviewQueryHandler.1Count.sql")]
    public void SqlFile_WithAnInvalidName_IsAnError(string fileName)
    {
        var result = Run(
            [(Folder + "/OrderOverviewQueryHandler.cs", HandlerSource)],
            [(Folder + "/" + fileName, "SELECT 1")]);

        AssertSingleError(result, "CATSQL003", fileName);
    }

    [Test]
    public void SqlFile_WhenTheConstantAlreadyExists_IsAnError()
    {
        var source = HandlerSource.Replace("public string Read()", "private const string Sql = \"x\";\n    public string Read()");
        var result = Run(
            [(Folder + "/OrderOverviewQueryHandler.cs", source)],
            [(Folder + "/OrderOverviewQueryHandler.sql", "SELECT 1")]);

        AssertSingleError(result, "CATSQL004", "OrderOverviewQueryHandler.sql");
    }

    [Test]
    public void SqlFile_ForAGenericClassInTheGlobalNamespace_KeepsTheTypeParameters()
    {
        var result = Run(
            [(Folder + "/Handler.cs", "public partial class Handler<TQuery, TResult> { public string Read() => Sql; }")],
            [(Folder + "/Handler.sql", "SELECT 1")]);

        Assert.Multiple(() =>
        {
            Assert.That(result.GeneratorDiagnostics, Is.Empty);
            Assert.That(result.GeneratedTrees[0].ToString(), Does.Contain("partial class Handler<TQuery, TResult>"));
            Assert.That(result.OutputDiagnostics.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);
        });
    }

    private static void AssertSingleError(RunResult result, string id, string fileName)
    {
        Assert.Multiple(() =>
        {
            Assert.That(result.GeneratorDiagnostics, Has.Length.EqualTo(1));
            Assert.That(result.GeneratorDiagnostics[0].Id, Is.EqualTo(id));
            Assert.That(result.GeneratorDiagnostics[0].Severity, Is.EqualTo(DiagnosticSeverity.Error));
            Assert.That(result.GeneratorDiagnostics[0].GetMessage(), Does.Contain(fileName));
        });
    }

    private static RunResult Run((string Path, string Text)[] sources, (string Path, string Text)[] sqlFiles)
    {
        var trees = sources.Select(s => CSharpSyntaxTree.ParseText(s.Text, path: s.Path)).ToArray();
        var references = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")!)
            .Split(Path.PathSeparator)
            .Select(path => MetadataReference.CreateFromFile(path))
            .ToArray();
        var compilation = CSharpCompilation.Create(
            "Tests",
            trees,
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, nullableContextOptions: NullableContextOptions.Enable));

        var driver = CSharpGeneratorDriver
            .Create(new SqlFilesGenerator())
            .AddAdditionalTexts(sqlFiles.Select(f => (AdditionalText)new SqlText(f.Path, f.Text)).ToImmutableArray())
            .RunGeneratorsAndUpdateCompilation(compilation, out var output, out var diagnostics);

        return new RunResult(
            driver.GetRunResult().GeneratedTrees,
            diagnostics.Where(d => d.Id.StartsWith("CATSQL")).ToImmutableArray(),
            output.GetDiagnostics());
    }

    private sealed record RunResult(
        ImmutableArray<SyntaxTree> GeneratedTrees,
        ImmutableArray<Diagnostic> GeneratorDiagnostics,
        IEnumerable<Diagnostic> OutputDiagnostics);

    private sealed class SqlText(string path, string text) : AdditionalText
    {
        public override string Path { get; } = path;

        public override SourceText GetText(CancellationToken cancellationToken = default) => SourceText.From(text);
    }
}
