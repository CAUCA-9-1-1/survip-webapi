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

	public class ReportBuildingAnomalyPictureGroupHandler : BaseReportGroupHandler<BuildingChildPictureForWeb>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.AnomalyPicture;

		public ReportBuildingAnomalyPictureGroupHandler(ManagementContext context) : base(context)
		{
		}

		protected override List<BuildingChildPictureForWeb> GetData(Guid idParent, string languageCode)
		{
			var query =
				from picAnomaly in Context.BuildingAnomalyPictures.AsNoTracking()
				where picAnomaly.IdBuildingAnomaly == idParent && picAnomaly.IsActive
				let pic = picAnomaly.Picture
				select new BuildingChildPictureForWeb
				{
					Id = pic.Id,
					IdPicture = pic.Id,
					PictureData = string.Format(
						"data:{0};base64,{1}",
						pic.MimeType == "" || pic.MimeType == null ? "image/jpeg" : pic.MimeType,
						Convert.ToBase64String(pic.Data)),
					SketchJson = pic.SketchJson
				};

			return query.ToList();
		}

		protected override string FormatPropertyValue((string name, string value) property)
		{
			if (property.name == "PictureData")
			{
				return "<img style=\"margin: 20px 20px\" src=\"data:image/png;base64, " +
				       property.value +
				       "\" height=\"400\" />";
			}
			return base.FormatPropertyValue(property);
		}
	}
}