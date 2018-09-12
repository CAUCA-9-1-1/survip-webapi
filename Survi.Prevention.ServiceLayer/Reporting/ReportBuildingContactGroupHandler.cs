using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingContactGroupHandler : BaseReportGroupHandler<BuildingContact>
	{
		private readonly BuildingContactService service;

		protected override ReportBuildingGroup Group => ReportBuildingGroup.BuildingContact;

		public ReportBuildingContactGroupHandler(BuildingContactService service)
		{
			this.service = service;
		}
		
		protected override List<BuildingContact> GetData(Guid idParent, string languageCode)
		{
			return service.GetBuildingContactList(idParent);
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.BuildingContact.ToString(), placeholders);
		}
	}
}