using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer
{
	public class ManagementContext : DbContext
	{
		public DbSet<AccessSecretKey> AccessSecretKeys { get; set; }
		public DbSet<AccessToken> AccessTokens { get; set; }
		public DbSet<Webuser> Webusers { get; set; }

		public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.AddEntityConfigurationsFromAssembly(GetType().Assembly);
			UseSnakeCaseMapping(modelBuilder);
		}

		private static void UseSnakeCaseMapping(ModelBuilder modelBuilder)
		{
			foreach (var entity in modelBuilder.Model.GetEntityTypes())
			{
				entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();

				foreach (var property in entity.GetProperties())
					property.Relational().ColumnName = property.Name.ToSnakeCase();

				foreach (var key in entity.GetKeys())
					key.Relational().Name = key.Relational().Name.ToSnakeCase();

				foreach (var key in entity.GetForeignKeys())
					key.Relational().Name = key.Relational().Name.ToSnakeCase();

				foreach (var index in entity.GetIndexes())
					index.Relational().Name = index.Relational().Name.ToSnakeCase();
			}
		}
	}
}
