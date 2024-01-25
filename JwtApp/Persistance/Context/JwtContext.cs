using JwtApp.Core.Domain;
using JwtApp.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JwtApp.Persistance.Context;

public class JwtContext : DbContext
{
    public JwtContext(DbContextOptions<JwtContext> options) : base(options) {}

    public DbSet<Product> Products { get; set; }
    public DbSet<Categoty> Categories { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppRole> AppRole { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        //modelBuilder.ApplyConfiguration(new AppUserConfiguration());

        //base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
