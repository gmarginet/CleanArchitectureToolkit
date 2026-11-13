// Keep this class in the root namespace of the project !!!
// ReSharper disable CheckNamespace
namespace Cat.Scheduling.EFCore;

// Ignore this class, it is only used by the DefaultDocumentation tool.
// The XML documentation of this class can be used for a general description of the namespace.

/// <summary>
/// Keeps the claims and the run history of the scheduler in the database of the service, so several instances
/// of the service never run the same job at the same due time, and a missed run is found after a restart.
/// </summary>
internal static class NamespaceDoc { }
