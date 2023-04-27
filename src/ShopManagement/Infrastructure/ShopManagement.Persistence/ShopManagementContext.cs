using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;
using ShopManagement.Domain.ProductAggregate.ProductModel;

namespace ShopManagement.Persistence;

public class ShopManagementContext : DbContext
{

    public ShopManagementContext(DbContextOptions<ShopManagementContext> options) : base(options)
    {

    }

    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
} 