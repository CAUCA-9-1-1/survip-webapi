using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using ImportedRisk = Survi.Prevention.ApiClient.DataTransferObjects.RiskLevel;
using DataRisk = Survi.Prevention.Models.Buildings.RiskLevel;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class RiskLevelImportationConverter
        : BaseLocalizableEntityConverter<
            ImportedRisk,
            DataRisk,
            RiskLevelLocalization>
    {
        public RiskLevelImportationConverter(
            IManagementContext context,
            AbstractValidator<ImportedRisk> validator, CacheSystem cache)
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ImportedRisk importedObject,
            DataRisk entity)
        {
            entity.Code = importedObject.Code;
            entity.Color = importedObject.Color.ToString();
            entity.Sequence = importedObject.Sequence;
        }
    }
}
