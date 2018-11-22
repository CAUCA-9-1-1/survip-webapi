using System.Text;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Import.Base;
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
            AbstractValidator<ImportedHydrantType> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ImportedHydrantType importedObject,
            DataHydrantType entity)
        {
        }
    }
}
