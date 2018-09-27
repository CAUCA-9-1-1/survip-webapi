using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Survi.Prevention.DataLayer
{
	public class ManagementContextFactory : IDesignTimeDbContextFactory<ManagementContext>
	{
		public ManagementContext CreateDbContext(string[] args)
		{
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();

			var builder = new DbContextOptionsBuilder<ManagementContext>();
			// Note that this connection string is solely used to create migrations stuff.  That's why it isn't part of a configuration file.
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
