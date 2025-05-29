using System;
using MahalliyMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace MahalliyMarket.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure your entity mappings here
        // For example:
        // modelBuilder.Entity<Product>().ToTable("Products");

        modelBuilder.Entity<Products>(entity =>
        {
            entity.ToTable("Products");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Description).HasMaxLength(500);
            entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
            entity.Property(p => p.ImageUrl).HasMaxLength(200);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("GETDATE()");
        });
    }
    
    public DbSet<Products> Products { get; set; }
}
