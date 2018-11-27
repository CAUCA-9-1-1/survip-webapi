using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using BuildingParticularRisk = Survi.Prevention.ApiClient.DataTransferObjects.BuildingParticularRisk;
using ParticularRiskType = Survi.Prevention.ApiClient.DataTransferObjects.ParticularRiskType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingParticularRiskImportationConverter
        : BaseEntityConverter<
            BuildingParticularRisk,
            Models.Buildings.Base.BuildingParticularRisk>
    {
        private ParticularRiskType riskType;

        public BuildingParticularRiskImportationConverter(
            IManagementContext context, 
            AbstractValidator<BuildingParticularRisk> validator, 
            ICustomFieldsCopier<BuildingParticularRisk, Models.Buildings.Base.BuildingParticularRisk> copier) 
            : base(context, validator, copier)
        {
        }

        public override ConversionResult<Models.Buildings.Base.BuildingParticularRisk> Convert(BuildingParticularRisk importedObject)
        {
            riskType = importedObject.RiskType;
            return base.Convert(importedObject);
        }

        protected override void GetRealForeignKeys(BuildingParticularRisk importedObject)
        {
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }

        protected override Models.Buildings.Base.BuildingParticularRisk CreateNew()
        {
            var entity = BuildingParticularRiskFactory.GetRisk(riskType);
            Context.Add(entity);
            return entity;
        }
    }
}