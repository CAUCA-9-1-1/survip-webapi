using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public interface IBaseBuildingAlarmPanel : IBaseModel
	{
		string Floor { get; set; }
		string Wall { get; set; }
		string Sector { get; set; }

		Guid? IdAlarmPanelType { get; set; }
		Guid IdBuilding { get; set; }

		AlarmPanelType AlarmPanelType { get; set; }
	}

	public abstract class BaseBuildingAlarmPanel<T> : BaseImportedModel, IBaseBuildingAlarmPanel
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