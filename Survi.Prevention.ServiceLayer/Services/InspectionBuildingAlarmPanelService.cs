using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingAlarmPanelService : BaseCrudService<BuildingAlarmPanel>
	{
		public InspectionBuildingAlarmPanelService(ManagementContext context) : base(context)
		{
		}

		public override BuildingAlarmPanel Get(Guid id)
		{
			var entity = Context.BuildingAlarmPanels.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}

		public override List<BuildingAlarmPanel> GetList()
		{
			throw new NotImplementedException();
		}

		public List<BuildingFireProtectionForList> GetListLocalized(string languageCode, Guid idBuilding)
		{
			var query =
				from panel in Context.BuildingAlarmPanels.AsNoTracking()
				where panel.IdBuilding == idBuilding && panel.IsActive
				let type = panel.AlarmPanelType
				from loc in type.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new
				{
					panel.Id,
					loc.Name,
					panel.Floor,
					panel.Sector,
					panel.Wall
				};

			var result =
				from panel in query.ToList()
				select new BuildingFireProtectionForList
				{
					Id = panel.Id,
					TypeDescription = panel.Name,
					LocationDescription = GetPanelLocationDescription(panel.Floor, panel.Sector, panel.Wall)
				};

			return result.ToList();
		}

		private string GetPanelLocationDescription(string floor, string sector, string wall)
		{
			var wallDescription = "";
			if (!string.IsNullOrWhiteSpace(wall))
				wallDescription = $"Mur: {wall}.";
			var sectorDescription = "";
			if (!string.IsNullOrWhiteSpace(sector))
				sectorDescription = $"Secteur: {sector}.";
			var floorDescription = "";
			if (!string.IsNullOrWhiteSpace(floor))
				floorDescription = $"Étage: {floor}.";

			return string.Join(" ", sectorDescription, floorDescription, wallDescription);
		}
	}
}