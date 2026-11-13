// Keep this class in the root namespace of the project !!!
// ReSharper disable CheckNamespace
namespace Cat.Scheduling;

// Ignore this class, it is only used by the DefaultDocumentation tool.
// The XML documentation of this class can be used for a general description of the namespace.

/// <summary>
/// The scheduler. It declares the jobs of a service, waits for their due times with a cron parser, claims every run
/// so only one instance runs it, and sends the service request of the job as a system user. It also holds the claim store in memory.
/// </summary>
internal static class NamespaceDoc { }
