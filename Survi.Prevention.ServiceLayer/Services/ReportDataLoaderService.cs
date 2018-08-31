using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Reporting;

namespace Survi.Prevention.ServiceLayer.Services
{
/*	public class ReportDataLoaderService : BaseService
	{
		public ReportDataLoaderService(ManagementContext context) : base(context)
		{
		}

		public string FillTemplate(string template, Guid inspectionId, string languageCode)
		{
			var buildingGroup = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.Building, template);
			var buildingIds = GetBuildingIds(inspectionId);
			var filledBuildingGroup = "";
			var buildingGroupHandler = new ReportBuildingGroupHandler(Context);
			foreach (var id in buildingIds)
				filledBuildingGroup += buildingGroupHandler.FillBuildingGroup(buildingGroup, id, languageCode);
			return template.Replace(buildingGroup, filledBuildingGroup);
		}

		private List<Guid> GetBuildingIds(Guid inspectionId)
		{
			var mainBuildingId = Context.Inspections.Where(i => i.Id == inspectionId).Select(i => i.IdBuilding).FirstOrDefault();

			if (mainBuildingId != Guid.Empty)
			{
				var query =
					from building in Context.Buildings.AsNoTracking()
					where building.IsActive && (building.Id == mainBuildingId || building.IdParentBuilding == mainBuildingId)
					select building.Id;

				return query.ToList();

			}

			return new List<Guid>();
		}				
	}*/
}