﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingAlarmPanelService : BaseCrudService<InspectionBuildingAlarmPanel>
	{
		public InspectionBuildingAlarmPanelService(IManagementContext context) : base(context)
		{
		}

		public override InspectionBuildingAlarmPanel Get(Guid id)
		{
			var entity = Context.InspectionBuildingAlarmPanels.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}
		
		public List<InspectionBuildingAlarmPanel> GetList(Guid idBuilding)
		{
			return Context.InspectionBuildingAlarmPanels
				.Where(p => p.IsActive && p.IdBuilding == idBuilding)
				.ToList();
		}

		public List<BuildingFireProtectionForList> GetListLocalized(string languageCode, Guid idBuilding)
		{
			var query =
				from panel in Context.InspectionBuildingAlarmPanels.AsNoTracking()
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
					LocationDescription = new LocalizedResourceGenerator().GetFireProtectionLocationDescription(panel.Floor, panel.Sector, panel.Wall,languageCode)
				};

			return result.ToList();
		}

		
	}
}