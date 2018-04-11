using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer.InitialData;

namespace Survi.Prevention.DataLayer
{
	public static class ManagementContextInitializer
	{
		private static readonly object Locker = new object();
		public static bool Initialized;

		public static void Initialize(ManagementContext context)
		{
			if (!Initialized)
			{
				lock (Locker)
				{
					if (Initialized)
						return;
					Initialized = true;
					InitializeDatabase(context);
				}
			}
		}

		private static void InitializeDatabase(ManagementContext context)
		{
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
			//context.Database.Migrate();

			if (!context.LaneGenericCodes.Any())
				context.AddRange(InitialLaneGenericCodesGenerator.GetInitialData().ToList());
			if (!context.LanePublicCodes.Any())
				context.AddRange(InitialLanePublicCodesGenerator.GetInitialData().ToList());
			if (!context.Webusers.Any())
				context.AddRange(InitialUserGenerator.GetInitialData().ToList());
			if (!context.PermissionSystems.Any())				
				context.AddRange(InitialPermissionGenerator.GetInitialData((context.Webusers.FirstOrDefault()??context.Webusers.Local.First()).Id));
			context.SaveChanges();
		}
	}
}