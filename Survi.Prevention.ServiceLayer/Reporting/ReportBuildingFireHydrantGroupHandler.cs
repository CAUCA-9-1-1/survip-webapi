using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingFireHydrantGroupHandler : BaseReportGroupHandler<FireHydrantForList>
	{
		private readonly BuildingFireHydrantService service;

		protected override ReportBuildingGroup Group => ReportBuildingGroup.MainBuildingFireHydrant;

		public ReportBuildingFireHydrantGroupHandler(BuildingFireHydrantService service)
		{
			this.service = service;	
		}
		
		protected override List<FireHydrantForList> GetData(Guid idParent, string languageCode)
		{
			return service.GetFireHydrants(idParent, languageCode);
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.MainBuildingFireHydrant.ToString(), placeholders);
		}
	}
}