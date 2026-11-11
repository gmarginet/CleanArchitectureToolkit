// Keep this class in the root namespace of the project !!!
// ReSharper disable CheckNamespace
namespace Cat.EventProcessor.Inbox.EFCore;

// Ignore this class, it is only used by the DefaultDocumentation tool.
// The XML documentation of this class can be used for a general description of the namespace.

/// <summary>
/// The optional inbox for EF Core, for handlers that cannot be idempotent.
/// It stores the ID of a handled message in the same <c>SaveChanges</c> as the work of the handler, so a repeated message is skipped.
/// </summary>
internal static class NamespaceDoc { }
