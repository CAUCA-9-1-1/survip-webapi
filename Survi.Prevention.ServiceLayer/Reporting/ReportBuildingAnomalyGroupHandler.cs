using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingAnomalyGroupHandler : BaseReportGroupHandlerWithChild<BuildingAnomalyForList>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.Anomaly;

		public ReportBuildingAnomalyGroupHandler(ManagementContext context) : base(context)
		{
		}

		protected override List<BuildingAnomalyForList> GetData(Guid idParent, string languageCode)
		{
			var query =
				from anomaly in Context.BuildingAnomalies.AsNoTracking()
				where anomaly.IdBuilding == idParent && anomaly.IsActive
				select new BuildingAnomalyForList
				{
					Id = anomaly.Id,
					Theme = anomaly.Theme,
					Notes = anomaly.Notes
				};

			return query.ToList();
		}

		protected override string FillChildren(string template, Guid idParent, string languageCode)
		{
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.AnomalyPicture, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.AnomalyPicture, template);
				var filledGroup = new ReportBuildingAnomalyPictureGroupHandler(Context).FillGroup(group, idParent, languageCode);
				template = template.Replace(group, filledGroup);
			}

			return template;
		}
	}
}