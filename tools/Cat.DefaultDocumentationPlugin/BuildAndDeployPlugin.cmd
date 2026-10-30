@echo off
rem Builds the plugin in Release and copies it to the folder the documentation build loads it from.

rem Run from the plugin folder, so the relative paths work wherever the script is started.
cd /d "%~dp0"

dotnet build Cat.DefaultDocumentationPlugin.csproj -c Release
if errorlevel 1 exit /b %errorlevel%

rem A previous documentation build can keep the plugin loaded in an MSBuild node, which locks the file.
dotnet build-server shutdown

copy .\bin\Release\netstandard2.0\Cat.DefaultDocumentationPlugin.dll ..\..\resources\defaultDocumentationPlugins\ /y
if errorlevel 1 exit /b %errorlevel%
copy .\bin\Release\netstandard2.0\Cat.Object.Extensions.dll ..\..\resources\defaultDocumentationPlugins\ /y
if errorlevel 1 exit /b %errorlevel%
