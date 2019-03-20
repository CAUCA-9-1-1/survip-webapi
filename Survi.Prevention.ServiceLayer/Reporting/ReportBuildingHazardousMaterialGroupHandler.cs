using System;
using System.Collections.Generic;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Localization.Base;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingHazardousMaterialGroupHandler : BaseReportGroupHandler<BuildingHazardousMaterialForReport>
	{
		private readonly BuildingHazardousMaterialService service;
		protected override ReportBuildingGroup Group => ReportBuildingGroup.BuildingHazardousMaterial;

		public ReportBuildingHazardousMaterialGroupHandler(BuildingHazardousMaterialService service)
		{
			this.service = service;
		}

		protected override List<BuildingHazardousMaterialForReport> GetData(Guid idParent, string languageCode)
		{
			return service.GetMaterialsForReport(idParent, languageCode);
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.BuildingHazardousMaterial.ToString(), placeholders);
		}

	    protected override string FormatPropertyValue((string name, object value) property, string languageCode)
	    {
	        if (property.value is StorageTankType type)
	            return GetTankTypeLocalized(type, languageCode);
	        return base.FormatPropertyValue(property, languageCode);
	    }

	    private string GetTankTypeLocalized(StorageTankType tankType, string languageCode)
	    {
	        return tankType.GetDisplayName(languageCode);
	    }
    }
}