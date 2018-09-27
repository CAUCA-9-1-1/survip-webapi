using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Survi.Prevention.DataLayer
{
	public class ManagementContextFactory : IDesignTimeDbContextFactory<ManagementContext>
	{
		public ManagementContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<ManagementContext>();
			// Note that this connection string is solely used to create migrations stuff.  That's why it isn't part of a configuration file.
			var connectionString = "[YOUR CONNECTION STRING FOR MIGRATION]"; //Configuration.GetConnectionString("SurviPreventionDatabase");
			builder.UseNpgsql(connectionString, npgOptions =>
			{
				npgOptions.CommandTimeout((int) TimeSpan.FromMinutes(10).TotalSeconds);
				npgOptions.UseNetTopologySuite();
			});
			return new ManagementContext(builder.Options);
		}
	}
}
