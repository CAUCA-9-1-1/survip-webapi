using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingSprinklerImportationConverter
        : BaseEntityConverter<
            BuildingSprinkler,
            Models.Buildings.BuildingSprinkler>
    {
        public BuildingSprinklerImportationConverter(
            IManagementContext context, 
            AbstractValidator<BuildingSprinkler> validator, 
            ICustomFieldsCopier<BuildingSprinkler, Models.Buildings.BuildingSprinkler> copier) 
            : base(context, validator, copier)
        {
        }

        protected override void GetRealForeignKeys(BuildingSprinkler importedObject)
        {
            importedObject.IdSprinklerType = GetRealId<Models.Buildings.SprinklerType>(importedObject.IdSprinklerType);
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }
    }
}