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
		    var copy = new TCopy();
		    hydrant.CopyProperties(copy);
		    return copy;
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