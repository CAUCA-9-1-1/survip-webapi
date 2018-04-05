using Microsoft.EntityFrameworkCore;
using Survip.DataLayer.Mapping.Base;
using Survip.Models.SecurityManagement;

namespace Survip.DataLayer
{
  public class ManagementContext : DbContext
  {
    public DbSet<AccessSecretKey> AccessSecretKeys { get; set; }
    public DbSet<AccessToken> AccessTokens { get; set; }
    public DbSet<Webuser> Webusers { get; set; }

    public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.AddEntityConfigurationsFromAssembly(GetType().Assembly);
    }
  }
}
