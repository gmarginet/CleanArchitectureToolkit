using System;
using System.Collections.Generic;
using Cat.Demo.InventoryService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.InventoryService.Infrastructure.DataAccess;

public partial class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StockItem> StockItems { get; set; }

    public virtual DbSet<StockReservation> StockReservations { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StockItem>(entity =>
        {
            entity.ToTable("StockItem");

            entity.HasIndex(e => new { e.WarehouseId, e.Isbn }, "UQ_StockItem_Warehouse_Isbn").IsUnique();

            entity.Property(e => e.Isbn).HasMaxLength(13);

            entity.HasOne(d => d.Warehouse).WithMany(p => p.StockItems)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockItem_Warehouse");
        });

        modelBuilder.Entity<StockReservation>(entity =>
        {
            entity.ToTable("StockReservation");

            entity.HasIndex(e => new { e.StockItemId, e.OrderNumber }, "UQ_StockReservation_StockItem_OrderNumber").IsUnique();

            entity.Property(e => e.OrderNumber).HasMaxLength(20);
            entity.Property(e => e.ReservedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_StockReservation_ReservedAt");

            entity.HasOne(d => d.StockItem).WithMany(p => p.StockReservations)
                .HasForeignKey(d => d.StockItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockReservation_StockItem");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");

            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
