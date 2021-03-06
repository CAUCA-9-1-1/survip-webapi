﻿using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingAnomalyImportationConverter
        : BaseEntityConverter<
            BuildingAnomaly,
            Models.Buildings.BuildingAnomaly>
    {
        public BuildingAnomalyImportationConverter(
            IManagementContext context,
            AbstractValidator<BuildingAnomaly> validator, 
            ICustomFieldsCopier<BuildingAnomaly, Models.Buildings.BuildingAnomaly> copier, CacheSystem cache)
            : base(context, validator, copier, cache)
        {
        }

        protected override void GetRealForeignKeys(BuildingAnomaly importedObject)
        {            
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }
    }
}