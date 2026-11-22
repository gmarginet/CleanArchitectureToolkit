// Merges the package versions of a service into Directory.Packages.Cat.props, the versions file of the solution.
// The template runs it with "dotnet run MergePackages.cs" when you use --NewSolution false, and the script removes itself afterwards.
// A package that the versions file has already keeps its version. A package with another version is reported and left as it is.
#:property ManagePackageVersionsCentrally=false
#:property ImportDirectoryBuildProps=false
using System.Xml.Linq;

var folder = Directory.GetCurrentDirectory();
var target = Path.Combine(folder, "Directory.Packages.Cat.props");

var files = Directory.GetFiles(folder, "*.Packages.props")
    .Where(file => !Path.GetFileName(file).StartsWith("Directory.", StringComparison.Ordinal))
    .OrderBy(file => file, StringComparer.Ordinal)
    .ToList();

foreach (var file in files)
{
    if (!File.Exists(target))
    {
        File.Move(file, target);
        Console.WriteLine($"Created {Path.GetFileName(target)} from {Path.GetFileName(file)}.");
        continue;
    }

    var existing = XDocument.Load(target);
    var incoming = XDocument.Load(file);
    var known = existing.Descendants("PackageVersion")
        .Where(element => element.Attribute("Include") is not null)
        .ToDictionary(element => (string)element.Attribute("Include")!, element => (string?)element.Attribute("Version"), StringComparer.OrdinalIgnoreCase);

    var added = new List<XElement>();
    foreach (var package in incoming.Descendants("PackageVersion"))
    {
        var id = (string?)package.Attribute("Include");
        if (id is null)
        {
            continue;
        }

        var version = (string?)package.Attribute("Version");
        if (known.TryGetValue(id, out var knownVersion))
        {
            if (!string.Equals(knownVersion, version, StringComparison.Ordinal))
            {
                Console.WriteLine($"Kept {id} {knownVersion}. {Path.GetFileName(file)} has {version}.");
            }

            continue;
        }

        added.Add(new XElement(package));
        known[id] = version;
    }

    if (added.Count > 0)
    {
        existing.Root!.Add(new XElement("ItemGroup", new XComment($" From {Path.GetFileName(file)} "), added));
        existing.Save(target);
    }

    File.Delete(file);
    Console.WriteLine($"Merged {Path.GetFileName(file)} into {Path.GetFileName(target)}: {added.Count} new packages.");
}

File.Delete(Path.Combine(folder, "MergePackages.cs"));
