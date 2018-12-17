using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using FireHydrantConnectionType = Survi.Prevention.ApiClient.DataTransferObjects.FireHydrantConnectionType;

namespace Survi.Prevention.ServiceLayer.Import.FireHydrantImportation
{
    public class FireHydrantConnectionTypeImportationConverter
        : BaseLocalizableEntityConverter<
            FireHydrantConnectionType,
            Models.FireHydrants.FireHydrantConnectionType,
            FireHydrantConnectionTypeLocalization>
    {
        public FireHydrantConnectionTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<FireHydrantConnectionType> validator, CacheSystem cache)
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            FireHydrantConnectionType importedObject,
            Models.FireHydrants.FireHydrantConnectionType entity)
        {
        }
    }
}