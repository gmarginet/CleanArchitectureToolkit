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
    
     var projectFiles = GetFiles("./modules/**/*.csproj");
     foreach (var file in projectFiles)
     {
        context.Information("Packing {0}", file.FullPath);
        DotNetPack(file.FullPath, settings);
     }
});

Task("Publish")
    .IsDependentOn("Pack")
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
