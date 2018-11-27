using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
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
            ICustomFieldsCopier<BuildingDetail, Models.Buildings.BuildingDetail> copier) 
            : base(context, validator, copier)
        {
        }

        protected override void GetRealForeignKeys(BuildingDetail importedObject)
        {
            importedObject.IdBuildingSidingType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdBuildingType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdConstructionFireResistanceType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdConstructionType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdRoofMaterialType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdRoofType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdUnitOfMeasureEstimatedWaterFlow = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdUnitOfMeasureHeight = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);

            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }

        protected override Models.Buildings.BuildingDetail GetEntityFromDatabase(string externalId)
        {
            return Context.Set<Models.Buildings.BuildingDetail>()
                .Include(pic => pic.PlanPicture)
                .FirstOrDefault(pic => pic.IdExtern == externalId);
        }
    }
}