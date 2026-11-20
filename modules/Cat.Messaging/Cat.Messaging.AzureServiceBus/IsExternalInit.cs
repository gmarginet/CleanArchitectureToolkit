// ReSharper disable CheckNamespace
namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Fix for Compile Error CS0518 Predefined type 'System.Runtime.CompilerServices.IsExternalInit' is
    /// not defined or imported.
    ///
    /// Many developers think this is a bug in dotnet. But unfortunately this is not a bug. The IsExternalInit
    /// type is only included in the net5.0 (and future) target frameworks. When compiling against older target
    /// frameworks you will need to manually define this type.
    /// <see href="https://developercommunity.visualstudio.com/t/error-cs0518-predefined-type-systemruntimecompiler/1244809">more info</see>
    /// </summary>
    internal static class IsExternalInit {}
}
