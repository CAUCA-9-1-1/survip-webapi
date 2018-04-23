using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingAlarmPanel : BaseModel
	{
		public string Floor { get; set; }
		public string Wall { get; set; }
		public string Sector { get; set; }

		public Guid? IdAlarmPanelType { get; set; }
		public Guid IdBuilding { get; set; }

		public AlarmPanelType AlarmPanelType { get; set; }
		public Building Building { get; set; }
	}
}