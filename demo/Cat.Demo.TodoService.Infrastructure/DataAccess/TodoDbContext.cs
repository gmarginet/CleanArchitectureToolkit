using Cat.Demo.TodoService.DataModels.Entities;
using Cat.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Validators.DataAccess;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options): base(options) {}

    public DbSet<Todo> Todos { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCatTemporalEntity<Todo>();
        modelBuilder.ConfigureCatEntity<Todo>();
    }
}
