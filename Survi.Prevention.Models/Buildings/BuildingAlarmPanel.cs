using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingAlarmPanel : BaseModel
	{
		public string AlarmPanelFloor { get; set; }
		public string AlarmPanelWall { get; set; }
		public string AlarmPanelSector { get; set; }

		public Guid? IdAlarmPanelType { get; set; }
		public Guid IdBuilding { get; set; }

		public AlarmPanelType AlarmPanelType { get; set; }
		public Building Building { get; set; }
	}
}