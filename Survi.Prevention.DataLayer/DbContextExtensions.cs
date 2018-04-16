using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer.Mapping.Base;

namespace Survi.Prevention.DataLayer
{
	public static class DbContextExtensions
	{
		public static void UseAutoDetectedMappings(this DbContext context, ModelBuilder builder)
		{
			builder.AddEntityConfigurationsFromAssembly(context.GetType().Assembly);
		}
	}
}