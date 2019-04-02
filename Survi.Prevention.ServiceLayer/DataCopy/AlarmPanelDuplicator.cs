using System.Collections.Generic;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class AlarmPanelDuplicator
	{
		public TCopy Duplicate<TOriginal, TCopy>(TOriginal panel)
			where TOriginal : IBaseBuildingAlarmPanel, new()
			where TCopy : IBaseBuildingAlarmPanel, new()
		{
		    var copy = new TCopy();
            panel.CopyProperties(copy);
		    return copy;
		}

		public IEnumerable<TCopy> Duplicate<TOriginal, TCopy>(ICollection<TOriginal> alarmPanels)
			where TOriginal : IBaseBuildingAlarmPanel, new()
			where TCopy : IBaseBuildingAlarmPanel, new()
		{
			foreach (var panel in alarmPanels)
				yield return Duplicate<TOriginal, TCopy>(panel);
		}
	}
}