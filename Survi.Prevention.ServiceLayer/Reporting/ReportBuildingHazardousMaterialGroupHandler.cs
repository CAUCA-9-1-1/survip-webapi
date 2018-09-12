using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingHazardousMaterialGroupHandler : BaseReportGroupHandler<BuildingHazardousMaterialForList>
	{
		private readonly BuildingHazardousMaterialService service;
		protected override ReportBuildingGroup Group => ReportBuildingGroup.BuildingHazardousMaterial;

		public ReportBuildingHazardousMaterialGroupHandler(BuildingHazardousMaterialService service)
		{
			this.service = service;
		}

		protected override List<BuildingHazardousMaterialForList> GetData(Guid idParent, string languageCode)
		{
			return service.GetMaterialsForList(idParent, languageCode);
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.BuildingHazardousMaterial.ToString(), placeholders);
		}
	}
}