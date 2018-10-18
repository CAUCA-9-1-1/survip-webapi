using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Survi.Prevention.DataLayer
{
	public class ManagementContextFactory : IDesignTimeDbContextFactory<ManagementContext>
	{
		public ManagementContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();

			var builder = new DbContextOptionsBuilder<ManagementContext>();
			var connectionString = configuration.GetConnectionString("SurviPreventionDatabaseForMigration");
			builder.UseNpgsql(connectionString, npgOptions =>
			{
				npgOptions.CommandTimeout((int) TimeSpan.FromMinutes(10).TotalSeconds);
				npgOptions.UseNetTopologySuite();
			});
			return new ManagementContext(builder.Options);
		}
	}
}
