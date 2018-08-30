using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingSprinklerGroupHandler : BaseReportGroupHandler<FireProtectionForReport>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.Sprinkler;

		public ReportBuildingSprinklerGroupHandler(ManagementContext context)
			: base(context)
		{
		}

		protected override List<FireProtectionForReport> GetData(Guid idParent, string languageCode)
		{
			var query =
				from sprinkler in Context.BuildingSprinklers.AsNoTracking()
				where sprinkler.IsActive && sprinkler.IdBuilding == idParent
				from localization in sprinkler.SprinklerType.Localizations.Where(loc => loc.IsActive && loc.LanguageCode == languageCode).DefaultIfEmpty()
				select new FireProtectionForReport
				{
					Floor = sprinkler.Floor,
					PipeLocation = sprinkler.PipeLocation,
					Wall = sprinkler.Wall,
					Sector = sprinkler.Sector,
					CollectorLocation = sprinkler.CollectorLocation,
					TypeName = localization.Name
				};

			return query.ToList();
		}
	}
}