using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using ImportedHydrantType = Survi.Prevention.ApiClient.DataTransferObjects.FireHydrantType;
using DataHydrantType = Survi.Prevention.Models.FireHydrants.FireHydrantType;

namespace Survi.Prevention.ServiceLayer.Import.FireHydrantImportation
{
    public class FireHydrantTypeImportationConverter
        : BaseLocalizableEntityConverter<
            ImportedHydrantType,
            DataHydrantType,
            FireHydrantTypeLocalization>
    {
        public FireHydrantTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<ImportedHydrantType> validator, CacheSystem cache)
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ImportedHydrantType importedObject,
            DataHydrantType entity)
        {
        }
    }
}
