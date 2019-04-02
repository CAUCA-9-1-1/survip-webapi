using System.Collections.Generic;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class HazardousMaterialDuplicator
	{
		public TCopy Duplicate<TOriginal, TCopy>(TOriginal material)
			where TOriginal : IBaseBuildingHazardousMaterial, new()
			where TCopy : IBaseBuildingHazardousMaterial, new()
		{
		    var copy = new TCopy();
		    material.CopyProperties(copy);
		    return copy;
		}

		public IEnumerable<TCopy> Duplicate<TOriginal, TCopy>(ICollection<TOriginal> materials)
			where TOriginal : IBaseBuildingHazardousMaterial, new()
			where TCopy : IBaseBuildingHazardousMaterial, new()
		{
			foreach (var material in materials)
				yield return Duplicate<TOriginal, TCopy>(material);
		}
	}
}