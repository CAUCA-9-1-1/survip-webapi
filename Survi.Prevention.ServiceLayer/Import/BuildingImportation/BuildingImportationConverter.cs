﻿using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using importedBuilding = Survi.Prevention.ApiClient.DataTransferObjects.Building;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
	public class BuildingImportationConverter : BaseLocalizableEntityWithPictureConverter<importedBuilding, Building, BuildingLocalization>
	{
		public BuildingImportationConverter
			(IManagementContext context, 
			AbstractValidator<importedBuilding> validator,
			ICustomFieldsCopier<importedBuilding, Building> copier) : base(context, validator, copier)
		{
		}

		protected override void GetRealForeignKeys(importedBuilding importedObject)
		{
			importedObject.IdCity = GetRealId<City>(importedObject.IdCity);
			importedObject.IdLane = GetRealId<Models.FireSafetyDepartments.Lane>(importedObject.IdLane);
			importedObject.IdRiskLevel = GetRealId<RiskLevel>(importedObject.IdRiskLevel);
			importedObject.IdLaneTransversal = GetRealId<Models.FireSafetyDepartments.Lane>(importedObject.IdLaneTransversal);
			importedObject.IdParentBuilding = GetRealId<Building>(importedObject.IdParentBuilding);		
			importedObject.IdUtilisationCode = GetRealId<UtilisationCode>(importedObject.IdUtilisationCode);
		}
	}
}