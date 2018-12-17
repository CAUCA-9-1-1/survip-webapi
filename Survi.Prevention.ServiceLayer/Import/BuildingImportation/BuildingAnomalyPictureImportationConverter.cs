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
    public class BuildingAnomalyPictureImportationConverter
        : BaseEntityConverter<
            BuildingAnomalyPicture,
            Models.Buildings.BuildingAnomalyPicture>
    {
        public BuildingAnomalyPictureImportationConverter(
            IManagementContext context, 
            AbstractValidator<BuildingAnomalyPicture> validator, 
            ICustomFieldsCopier<BuildingAnomalyPicture, Models.Buildings.BuildingAnomalyPicture> copier, CacheSystem cache)
            : base(context, validator, copier, cache)
        {
        }

        protected override void GetRealForeignKeys(BuildingAnomalyPicture importedObject)
        {
            importedObject.IdBuildingAnomaly = GetRealId<Models.Buildings.BuildingAnomaly>(importedObject.IdBuildingAnomaly);
        }

        protected override Models.Buildings.BuildingAnomalyPicture CreateNew()
        {
            var entity = base.CreateNew();
            entity.Picture = new Models.Picture();
            return entity;
        }

        protected override Models.Buildings.BuildingAnomalyPicture GetEntityFromDatabase(string externalId)
        {
            var entity = Context.Set<Models.Buildings.BuildingAnomalyPicture>()
                .IgnoreQueryFilters()
                .Include(pic => pic.Picture)
                .FirstOrDefault(pic => pic.IdExtern == externalId);

            if (entity != null && entity.Picture == null)
                entity.Picture = new Models.Picture();

            return entity;
        }
    }
}