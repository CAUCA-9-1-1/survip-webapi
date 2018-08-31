using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingParticularRiskGroupHandler : BaseReportGroupHandlerWithChild<ParticularRiskForReport>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.ParticularRisk;

		public ReportBuildingParticularRiskGroupHandler(ManagementContext context) : base(context)
		{
		}

		protected override List<ParticularRiskForReport> GetData(Guid idParent, string languageCode)
		{
			var query =
				from risk in Context.BuildingParticularRisks.AsNoTracking()
				where risk.IdBuilding == idParent && risk.IsActive
				select new ParticularRiskForReport
				{
					Comments = risk.Comments,
					Dimension = risk.Dimension,
					HasOpening = risk.HasOpening,
					IsWeakened = risk.IsWeakened,
					Sector = risk.Sector,
					Wall = risk.Wall,
					TypeName = risk is WallParticularRisk ? "Mur" : 
						risk is RoofParticularRisk ? "Toit" : 
						risk is FloorParticularRisk ? "Plancher" : 
						"Fondation"
				};

			return query.ToList();
		}

		protected override string FillChildren(string template, Guid idParent, string languageCode)
		{
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.ParticularRiskPicture, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.ParticularRiskPicture, template);
				var filledGroup = new ReportBuildingParticularRiskPictureGroupHandler(Context).FillGroup(group, idParent, languageCode);
				template = template.Replace(group, filledGroup);
			}

			return template;
		}
	}
}