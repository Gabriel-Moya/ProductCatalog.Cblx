using Microsoft.EntityFrameworkCore;
using ProductCatalog.Cblx.Domain.Entities;
using ProductCatalog.Cblx.Infra.Data.Seeders;

namespace ProductCatalog.Cblx.Infra.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Product>().HasKey(x => x.Id);

        modelBuilder.Entity<Product>().Property(x => x.Name);
        modelBuilder.Entity<Product>().Property(x => x.Description);
        modelBuilder.Entity<Product>().Property(x => x.Price);
        modelBuilder.Entity<Product>().Property(x => x.Quantity);
        modelBuilder.Entity<Product>().Property(x => x.ProductType);
        modelBuilder.Entity<Product>().Property(x => x.CreatedAtUtc);
    }
}
