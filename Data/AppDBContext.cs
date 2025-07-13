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
    }
}
