using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingDetailImportationConverter
        : BaseEntityConverter<
            BuildingDetail,
            Models.Buildings.BuildingDetail>
    {
        public BuildingDetailImportationConverter(
            IManagementContext context, 
            AbstractValidator<BuildingDetail> validator, 
            ICustomFieldsCopier<BuildingDetail, Models.Buildings.BuildingDetail> copier, CacheSystem cache)
            : base(context, validator, copier, cache)
        {
        }

        protected override void GetRealForeignKeys(BuildingDetail importedObject)
        {
            importedObject.IdBuildingSidingType = GetRealId<Models.Buildings.SidingType>(importedObject.IdBuildingSidingType);
            importedObject.IdBuildingType = GetRealId<Models.Buildings.BuildingType>(importedObject.IdBuildingType);
            importedObject.IdConstructionFireResistanceType = GetRealId<Models.Buildings.ConstructionFireResistanceType>(importedObject.IdConstructionFireResistanceType);
            importedObject.IdConstructionType = GetRealId<Models.Buildings.ConstructionType>(importedObject.IdConstructionType);
            importedObject.IdRoofMaterialType = GetRealId<Models.Buildings.RoofMaterialType>(importedObject.IdRoofMaterialType);
            importedObject.IdRoofType = GetRealId<Models.Buildings.RoofType>(importedObject.IdRoofType);
            importedObject.IdUnitOfMeasureEstimatedWaterFlow = GetRealId<Models.UnitOfMeasure>(importedObject.IdUnitOfMeasureEstimatedWaterFlow);
            importedObject.IdUnitOfMeasureHeight = GetRealId<Models.UnitOfMeasure>(importedObject.IdUnitOfMeasureHeight);

            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }

        protected override Models.Buildings.BuildingDetail GetEntityFromDatabase(string externalId)
        {
            return Context.Set<Models.Buildings.BuildingDetail>()
                .IgnoreQueryFilters()
                .Include(pic => pic.PlanPicture)
                .FirstOrDefault(pic => pic.IdExtern == externalId);
        }
    }
}