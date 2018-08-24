using System.Collections.Generic;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class FireHydrantDuplicator
	{
		public TCopy Duplicate<TOriginal, TCopy>(TOriginal hydrant)
			where TOriginal : IBaseBuildingFireHydrant, new()
			where TCopy : IBaseBuildingFireHydrant, new()
		{
			return new TCopy
			{
				CreatedOn = hydrant.CreatedOn,
				DeletedOn = hydrant.DeletedOn,
				Id = hydrant.Id,
				IdBuilding = hydrant.IdBuilding,
				IdFireHydrant = hydrant.IdFireHydrant,
				IsActive = hydrant.IsActive
			};
		}

		public IEnumerable<TCopy> Duplicate<TOriginal, TCopy>(ICollection<TOriginal> hydrants)
			where TOriginal : IBaseBuildingFireHydrant, new()
			where TCopy : IBaseBuildingFireHydrant, new()
		{
			foreach (var hydrant in hydrants)
				yield return Duplicate<TOriginal, TCopy>(hydrant);
		}
	}
}