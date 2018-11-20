using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingAlarmPanelService : BaseService
	{
		public BuildingAlarmPanelService(IManagementContext context) : base(context)
		{
		}

		public List<FireProtectionForReport> GetPanelsForReport(Guid idParent, string languageCode)
		{
			var query =
				from panel in Context.BuildingAlarmPanels.AsNoTracking()
				where panel.IsActive && panel.IdBuilding == idParent
				from localization in panel.AlarmPanelType.Localizations.Where(loc => loc.IsActive && loc.LanguageCode == languageCode).DefaultIfEmpty()
				select new FireProtectionForReport
				{
					Floor = panel.Floor,
					Wall = panel.Wall,
					Sector = panel.Sector,
					TypeName = localization.Name
				};

			return query.ToList();
		}
	}
}