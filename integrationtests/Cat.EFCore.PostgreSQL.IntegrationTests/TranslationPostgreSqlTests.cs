using Cat.IntegrationTesting.PostgreSQL.NUnit;
using Microsoft.EntityFrameworkCore;

namespace Cat.EFCore.IntegrationTests;

/// <summary>
/// The PostgreSQL part of the translation tests. The tests are in the shared file.
/// </summary>
public partial class TranslationIntegrationTests : PostgreSQLDatabaseTests
{
    private static void UseDatabase(DbContextOptionsBuilder options, string connectionString) => options.UseNpgsql(connectionString);
}
