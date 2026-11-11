// Keep this class in the root namespace of the project !!!
// ReSharper disable CheckNamespace
namespace Cat.Messaging.Outbox.EFCore;

// Ignore this class, it is only used by the DefaultDocumentation tool.
// The XML documentation of this class can be used for a general description of the namespace.

/// <summary>
/// The outbox table for EF Core. A message is added to the same <c>DbContext</c> as the entities,
/// so one <c>SaveChanges</c> saves both.
/// </summary>
internal static class NamespaceDoc { }
