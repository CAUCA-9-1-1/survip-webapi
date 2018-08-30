using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingContactGroupHandler : BaseReportGroupHandler<BuildingContact>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.Contact;

		public ReportBuildingContactGroupHandler(ManagementContext context) 
			: base(context)
		{
		}
		
		protected override List<BuildingContact> GetData(Guid idParent, string languageCode)
		{
			var query =
				from contact in Context.BuildingContacts.AsNoTracking()
				where contact.IsActive && contact.IdBuilding == idParent
				select contact;

			return query.ToList();
		}
	}
}