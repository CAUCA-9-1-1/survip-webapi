using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public abstract class BaseBuildingAlarmPanel<T> : BaseModel
		where T: BaseBuilding
	{
		public string Floor { get; set; }
		public string Wall { get; set; }
		public string Sector { get; set; }

		public Guid? IdAlarmPanelType { get; set; }
		public Guid IdBuilding { get; set; }

		public AlarmPanelType AlarmPanelType { get; set; }
		public T Building { get; set; }
	}
}