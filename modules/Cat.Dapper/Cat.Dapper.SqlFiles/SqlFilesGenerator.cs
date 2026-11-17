using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Cat.Dapper.SqlFiles;

/// <summary>
/// Creates a <c>private const string</c> in a handler class for each <c>.sql</c> file next to it.
/// <c>OrderOverviewQueryHandler.sql</c> gives the constant <c>Sql</c>, and
/// <c>OrderOverviewQueryHandler.Count.sql</c> gives <c>CountSql</c>.
/// </summary>
[Generator(LanguageNames.CSharp)]
public sealed class SqlFilesGenerator : IIncrementalGenerator
{
    private const string Category = "Cat.Dapper.SqlFiles";

    internal static readonly DiagnosticDescriptor NoMatchingClass = new(
        "CATSQL001",
        "No class for the SQL file",
        "The SQL file '{0}' has no class named '{1}' in the same folder",
        Category,
        DiagnosticSeverity.Error,
        true);

    internal static readonly DiagnosticDescriptor ClassNotPartial = new(
        "CATSQL002",
        "The class of an SQL file must be partial",
        "The class '{1}' must be partial to get the constant of the SQL file '{0}'",
        Category,
        DiagnosticSeverity.Error,
        true);

    internal static readonly DiagnosticDescriptor InvalidName = new(
        "CATSQL003",
        "The name of the SQL file is not valid",
        "The name of the SQL file '{0}' must be '<Class>.sql' or '<Class>.<Name>.sql', and every part must be a valid C# name",
        Category,
        DiagnosticSeverity.Error,
        true);

    internal static readonly DiagnosticDescriptor ConstantExists = new(
        "CATSQL004",
        "The constant of the SQL file already exists",
        "The class '{1}' already has a member named '{2}', so the SQL file '{0}' cannot create it",
        Category,
        DiagnosticSeverity.Error,
        true);

    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var sqlFiles = context.AdditionalTextsProvider
            .Where(static text => text.Path.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
            .Select(static (text, cancellationToken) => new SqlFile(text.Path, text.GetText(cancellationToken)?.ToString() ?? string.Empty))
            .Collect();

        var classes = context.SyntaxProvider
            .CreateSyntaxProvider(
                static (node, _) => node is ClassDeclarationSyntax { Parent: not TypeDeclarationSyntax },
                static (syntaxContext, cancellationToken) => ClassInfo.Create(syntaxContext, cancellationToken))
            .Where(static info => info is not null)
            .Select(static (info, _) => info!)
            .Collect();

        context.RegisterSourceOutput(sqlFiles.Combine(classes), static (output, source) => Generate(output, source.Left, source.Right));
    }

    private static void Generate(SourceProductionContext output, ImmutableArray<SqlFile> files, ImmutableArray<ClassInfo> classes)
    {
        var usedHints = new HashSet<string>(StringComparer.Ordinal);
        var takenMembers = new Dictionary<ClassInfo, HashSet<string>>();

        foreach (var file in files.OrderBy(static f => f.Path, StringComparer.Ordinal))
        {
            var fileName = Path.GetFileName(file.Path);
            var parts = Path.GetFileNameWithoutExtension(fileName).Split('.');

            if (parts.Length > 2 || parts.Any(static p => !SyntaxFacts.IsValidIdentifier(p)))
            {
                output.ReportDiagnostic(Diagnostic.Create(InvalidName, Location.None, fileName));
                continue;
            }

            var className = parts[0];
            var constantName = (parts.Length == 2 ? parts[1] : string.Empty) + "Sql";
            var folder = Normalize(Path.GetDirectoryName(file.Path));

            var target = classes.FirstOrDefault(c => c.Name == className && c.Folders.Contains(folder));
            if (target is null)
            {
                output.ReportDiagnostic(Diagnostic.Create(NoMatchingClass, Location.None, fileName, className));
                continue;
            }

            if (!target.IsPartial)
            {
                output.ReportDiagnostic(Diagnostic.Create(ClassNotPartial, Location.None, fileName, className));
                continue;
            }

            if (!takenMembers.TryGetValue(target, out var taken))
            {
                taken = new HashSet<string>(target.MemberNames, StringComparer.Ordinal);
                takenMembers[target] = taken;
            }

            if (!taken.Add(constantName))
            {
                output.ReportDiagnostic(Diagnostic.Create(ConstantExists, Location.None, fileName, className, constantName));
                continue;
            }

            var hint = $"{(target.Namespace.Length == 0 ? "global" : target.Namespace)}.{className}{target.TypeParameterHint}.{constantName}.g.cs";
            if (!usedHints.Add(hint))
            {
                hint = $"{hint}.{usedHints.Count}.g.cs";
            }

            output.AddSource(hint, SourceText.From(Render(target, constantName, file.Text), Encoding.UTF8));
        }
    }

    private static string Render(ClassInfo target, string constantName, string sql)
    {
        var text = new StringBuilder();
        text.AppendLine("// <auto-generated>Created by Cat.Dapper.SqlFiles from a .sql file.</auto-generated>");
        text.AppendLine("#nullable enable");

        var indent = string.Empty;
        if (target.Namespace.Length > 0)
        {
            text.AppendLine($"namespace {target.Namespace}");
            text.AppendLine("{");
            indent = "    ";
        }

        text.AppendLine($"{indent}partial class {target.Name}{target.TypeParameters}");
        text.AppendLine($"{indent}{{");
        text.AppendLine($"{indent}    private const string {constantName} = @\"{sql.Replace("\"", "\"\"")}\";");
        text.AppendLine($"{indent}}}");

        if (target.Namespace.Length > 0)
        {
            text.AppendLine("}");
        }

        return text.ToString();
    }

    internal static string Normalize(string? folder) => (folder ?? string.Empty).Replace('\\', '/').TrimEnd('/');

    private sealed class SqlFile
    {
        public SqlFile(string path, string text)
        {
            Path = path;
            Text = text;
        }

        public string Path { get; }

        public string Text { get; }

        public override bool Equals(object? obj) => obj is SqlFile other && Path == other.Path && Text == other.Text;

        public override int GetHashCode() => (Path.GetHashCode() * 397) ^ Text.GetHashCode();
    }

    private sealed class ClassInfo
    {
        private ClassInfo(string name, string @namespace, string typeParameters, string[] folders, bool isPartial, string[] memberNames)
        {
            Name = name;
            Namespace = @namespace;
            TypeParameters = typeParameters;
            Folders = folders;
            IsPartial = isPartial;
            MemberNames = memberNames;
        }

        public string Name { get; }

        public string Namespace { get; }

        public string TypeParameters { get; }

        public string TypeParameterHint => TypeParameters.Length == 0 ? string.Empty : "`" + (TypeParameters.Count(static c => c == ',') + 1);

        public string[] Folders { get; }

        public bool IsPartial { get; }

        public string[] MemberNames { get; }

        public static ClassInfo? Create(GeneratorSyntaxContext context, System.Threading.CancellationToken cancellationToken)
        {
            if (context.Node is not ClassDeclarationSyntax declaration
                || context.SemanticModel.GetDeclaredSymbol(declaration, cancellationToken) is not INamedTypeSymbol symbol)
            {
                return null;
            }

            var syntaxes = symbol.DeclaringSyntaxReferences;
            var folders = syntaxes
                .Select(static r => Normalize(Path.GetDirectoryName(r.SyntaxTree.FilePath)))
                .Distinct(StringComparer.Ordinal)
                .OrderBy(static f => f, StringComparer.Ordinal)
                .ToArray();
            var isPartial = syntaxes
                .Select(static r => r.GetSyntax(CancellationTokenNone))
                .OfType<ClassDeclarationSyntax>()
                .Any(static d => d.Modifiers.Any(SyntaxKind.PartialKeyword));
            var typeParameters = symbol.TypeParameters.Length == 0
                ? string.Empty
                : "<" + string.Join(", ", symbol.TypeParameters.Select(static p => p.Name)) + ">";
            var members = symbol.GetMembers().Select(static m => m.Name).Distinct(StringComparer.Ordinal).OrderBy(static n => n, StringComparer.Ordinal).ToArray();

            return new ClassInfo(
                symbol.Name,
                symbol.ContainingNamespace.IsGlobalNamespace ? string.Empty : symbol.ContainingNamespace.ToDisplayString(),
                typeParameters,
                folders,
                isPartial,
                members);
        }

        private static System.Threading.CancellationToken CancellationTokenNone => default;

        public override bool Equals(object? obj) =>
            obj is ClassInfo other
            && Name == other.Name
            && Namespace == other.Namespace
            && TypeParameters == other.TypeParameters
            && IsPartial == other.IsPartial
            && Folders.SequenceEqual(other.Folders)
            && MemberNames.SequenceEqual(other.MemberNames);

        public override int GetHashCode() => (Name.GetHashCode() * 397) ^ Namespace.GetHashCode();
    }
}
