var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");
var semanticVersion = Argument("semanticversion", "0.0.0-local");
var buildVersion = semanticVersion.Split(new char[] { '-' }).FirstOrDefault() ?? semanticVersion;

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectories($"./modules/**/bin/{configuration}", new CleanDirectorySettings()
    {
        Force = true
    });
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(context =>
{
    context.Information("Build version: {0}", semanticVersion);
    
    DotNetBuild("./CleanArchitectureToolkit.slnx", new DotNetBuildSettings
    {
        Configuration = configuration,
        NoIncremental = true,
        MSBuildSettings = new DotNetMSBuildSettings 
        {
            Version = buildVersion,
            AssemblyVersion = buildVersion,
            FileVersion = buildVersion
        }
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(context =>
{
     var settings = new DotNetTestSettings
     {
         Configuration = "Release",
         NoBuild = true
     };

     var projectFiles = GetFiles("./tests/**/*.Tests.csproj")
         .Concat(GetFiles("./demo/**/*.Tests.csproj"));
     foreach (var file in projectFiles)
     {
        context.Information("Testing {0}", file.FullPath);
         DotNetTest(file.FullPath, settings);
     }

     // The Node.js projects of the demo have their own tests. Node.js 22.18 or later is needed for the provider.
     // On Windows npm is a script, npm.cmd, which only runs right when the command prompt starts it.
     var npm = IsRunningOnWindows() ? "cmd" : "npm";
     foreach (var folder in new[] { "./demo/Cat.Demo.PaymentProvider", "./demo/Cat.Demo.WebClient/Cat.Demo.WebClient.App" })
     {
        foreach (var command in new[] { "ci", "test" })
        {
            context.Information("npm {0} in {1}", command, folder);
            var exitCode = StartProcess(npm, new ProcessSettings
            {
                Arguments = IsRunningOnWindows() ? "/c npm " + command : command,
                WorkingDirectory = folder
            });
            if (exitCode != 0)
            {
                throw new CakeException($"npm {command} failed in {folder} with exit code {exitCode}.");
            }
        }
     }
});

// The integration tests start containers, so they need Docker. They never run with the Test target.
// The projects are named *.IntegrationTests.csproj, which the pattern *.Tests.csproj of the Test target does not match.
Task("IntegrationTest")
    .IsDependentOn("Build")
    .Does(context =>
{
     var settings = new DotNetTestSettings
     {
         Configuration = configuration,
         NoBuild = true
     };

     var projectFiles = GetFiles("./integrationtests/**/*.IntegrationTests.csproj")
         .Concat(GetFiles("./demo/**/*.IntegrationTests.csproj"));
     foreach (var file in projectFiles)
     {
        context.Information("Integration testing {0}", file.FullPath);
         DotNetTest(file.FullPath, settings);
     }
});

Task("Pack")
    .IsDependentOn("Test")
    .Does(context =>
{
    CleanDirectory("./artifacts/");
    
    var settings = new DotNetPackSettings
     {
         Configuration = "Release",
         OutputDirectory = "./artifacts/",
         NoBuild = true,
         MSBuildSettings = new DotNetMSBuildSettings 
         {
            PackageVersion = semanticVersion
         }
     };
    
     // The template pack lives in templates/. Its content has project files of its own that are no projects of the toolkit,
     // so only the project of the pack itself is packed.
     var projectFiles = GetFiles("./modules/**/*.csproj")
         .Concat(GetFiles("./templates/Cat.Templates/Cat.Templates.csproj"));
     foreach (var file in projectFiles)
     {
        context.Information("Packing {0}", file.FullPath);
        DotNetPack(file.FullPath, settings);
     }
});

// The template tests create services from the template pack, build them against the packed modules and run their tests.
// They need the packs that the Pack target makes, so they never run with the Test target. Publish runs them first,
// so a template that no longer builds against a changed module is never published.
Task("TemplateTest")
    .IsDependentOn("Pack")
    .Does(context =>
{
    var templatePack = GetFiles("./artifacts/gmarginet.Cat.Templates.*.nupkg").FirstOrDefault()
        ?? throw new CakeException("The template pack is missing in ./artifacts.");

    var settings = new DotNetTestSettings
    {
        Configuration = configuration,
        EnvironmentVariables = new Dictionary<string, string>
        {
            ["CAT_TEMPLATE_PACK"] = templatePack.FullPath,
            ["CAT_PACKAGE_FEED"] = MakeAbsolute(Directory("./artifacts")).FullPath
        }
    };

    foreach (var file in GetFiles("./tests/**/*.TemplateTests.csproj"))
    {
        context.Information("Template testing {0}", file.FullPath);
        DotNetTest(file.FullPath, settings);
    }
});

Task("Publish")
    .IsDependentOn("TemplateTest")
    .Does(context =>
{
    var apiKey =  context.EnvironmentVariable("NUGET_API_KEY");
    if (string.IsNullOrWhiteSpace(apiKey)) {
        throw new CakeException("No NuGet API key specified.");
    }
    
    var nugetFiles = GetFiles("./artifacts/*.nupkg");
    foreach (var file in nugetFiles)
    {
        context.Information("Publishing {0}", file.FullPath);
        DotNetNuGetPush(file.FullPath, new DotNetNuGetPushSettings {
             Source = "https://api.nuget.org/v3/index.json",
             ApiKey = apiKey,
             SkipDuplicate = true
         });
    }
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
