using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CountryImportationConverter 
        : BaseLocalizableEntityConverter<
            ApiClient.DataTransferObjects.Country, 
            Models.FireSafetyDepartments.Country, 
            CountryLocalization>
    {
        public CountryImportationConverter(
            IManagementContext context, 
            AbstractValidator<ApiClient.DataTransferObjects.Country> validator) 
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ApiClient.DataTransferObjects.Country importedObject, 
            Models.FireSafetyDepartments.Country entity)
        {
            entity.CodeAlpha2 = importedObject.CodeAlpha2;
            entity.CodeAlpha3 = importedObject.CodeAlpha3;
        }
    }
}
