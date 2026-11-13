// Keep this class in the root namespace of the project !!!
// ReSharper disable CheckNamespace
namespace Cat.Db.Errors.SqlServer;

// Ignore this class, it is only used by the DefaultDocumentation tool.
// The XML documentation of this class can be used for a general description of the namespace.

/// <summary>
/// Recognizes SQL Server errors by their error number, such as a unique key violation, a foreign key violation,
/// a deadlock or a timeout. The checks work on any exception that has a SQL Server exception inside, so they also work
/// on the exception that Entity Framework Core throws around it.
/// </summary>
internal static class NamespaceDoc { }
