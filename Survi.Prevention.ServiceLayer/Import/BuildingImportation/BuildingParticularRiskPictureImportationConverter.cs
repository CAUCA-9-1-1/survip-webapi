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
    public class BuildingParticularRiskPictureImportationConverter
        : BaseEntityConverter<
            BuildingParticularRiskPicture,
            Models.Buildings.BuildingParticularRiskPicture>
    {
        public BuildingParticularRiskPictureImportationConverter(
            IManagementContext context, 
            AbstractValidator<BuildingParticularRiskPicture> validator, 
            ICustomFieldsCopier<BuildingParticularRiskPicture, Models.Buildings.BuildingParticularRiskPicture> copier, CacheSystem cache)
            : base(context, validator, copier, cache)
        {
        }

        protected override void GetRealForeignKeys(BuildingParticularRiskPicture importedObject)
        {
            importedObject.IdBuildingParticularRisk = GetRealId<Models.Buildings.Base.BuildingParticularRisk>(importedObject.IdBuildingParticularRisk);
        }

        protected override Models.Buildings.BuildingParticularRiskPicture CreateNew()
        {
            var entity = base.CreateNew();
            entity.Picture = new Models.Picture();
            return entity;
        }

        protected override Models.Buildings.BuildingParticularRiskPicture GetEntityFromDatabase(string externalId)
        {
            var entity = Context.Set<Models.Buildings.BuildingParticularRiskPicture>()
                .IgnoreQueryFilters()
                .Include(pic => pic.Picture)
                .FirstOrDefault(pic => pic.IdExtern == externalId);

            if (entity != null && entity.Picture == null)
                entity.Picture = new Models.Picture();

            return entity;
        }
    }
}