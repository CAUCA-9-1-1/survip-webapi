using System.Collections.Generic;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class SprinklerDuplicator
	{
		public TCopy Duplicate<TOriginal, TCopy>(TOriginal sprinkler)
			where TOriginal : IBaseBuildingSprinkler, new()
			where TCopy : IBaseBuildingSprinkler, new()
		{
			return new TCopy
			{
				CollectorLocation = sprinkler.CollectorLocation,
				CreatedOn = sprinkler.CreatedOn,
				Floor = sprinkler.Floor,
				Id = sprinkler.Id,
				IdBuilding = sprinkler.IdBuilding,
				IdSprinklerType = sprinkler.IdSprinklerType,
				IsActive = sprinkler.IsActive,
				PipeLocation = sprinkler.PipeLocation,
				Sector = sprinkler.Sector,
				Wall = sprinkler.Wall
			};
		}

		public IEnumerable<TCopy> Duplicate<TOriginal, TCopy>(ICollection<TOriginal> sprinklers)
			where TOriginal : IBaseBuildingSprinkler, new()
			where TCopy : IBaseBuildingSprinkler, new()
		{
			foreach (var sprinkler in sprinklers)
				yield return Duplicate<TOriginal, TCopy>(sprinkler);
		}
	}
}