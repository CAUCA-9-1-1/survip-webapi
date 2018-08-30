using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingPersonRequiringAssistanceGroupHandler : BaseReportGroupHandler<ContactForReport>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.PersonRequiringAssistance;

		public ReportBuildingPersonRequiringAssistanceGroupHandler(ManagementContext context) : base(context)
		{
		}
		
		protected override List<ContactForReport> GetData(Guid idParent, string languageCode)
		{
			var query =
				from person in Context.BuildingPersonsRequiringAssistance.AsNoTracking()
				where person.IsActive && person.IdBuilding == idParent
				from localization in person.PersonType.Localizations.Where(loc => loc.IsActive && loc.LanguageCode == languageCode).DefaultIfEmpty()
				select new ContactForReport
				{
					DayResidentCount = person.DayResidentCount,
					ContactName = person.ContactName,
					ContactPhoneNumber = person.ContactPhoneNumber,
					DayIsApproximate = person.DayIsApproximate,
					Description = person.Description,
					EveningIsApproximate = person.EveningIsApproximate,
					EveningResidentCount = person.EveningResidentCount,
					NightIsApproximate = person.NightIsApproximate,
					NightResidentCount = person.NightResidentCount,
					Local = person.Local,
					PersonName = person.PersonName,
					TypeName = localization.Name
				};

			return query.ToList();
		}
	}
}