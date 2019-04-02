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
		    var copy = new TCopy();
		    sprinkler.CopyProperties(copy);
		    return copy;
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