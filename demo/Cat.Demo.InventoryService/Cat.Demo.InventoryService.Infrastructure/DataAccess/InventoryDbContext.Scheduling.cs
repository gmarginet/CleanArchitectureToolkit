using Cat.Scheduling.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.InventoryService.Infrastructure.DataAccess;

/// <summary>
/// The part of the context that the scaffold does not generate. The table <c>CatJobRun</c> belongs to the scheduler.
/// It comes from <c>004-scheduling.sql</c>, and the scaffold skips it, see <c>Scaffold-InventoryModel.ps1</c>.
/// </summary>
public partial class InventoryDbContext
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.AddCatScheduling();
    }
}
