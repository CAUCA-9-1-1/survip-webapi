using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedCountry = Survi.Prevention.ApiClient.DataTransferObjects.Country;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CountryImportationConverter : BaseLocalizableEntityConverter<importedCountry, Country, CountryLocalization>
    {
        public CountryImportationConverter(IManagementContext context, AbstractValidator<importedCountry> validator) 
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(importedCountry importedObject, Country entity)
        {
            entity.CodeAlpha2 = importedObject.CodeAlpha2;
            entity.CodeAlpha3 = importedObject.CodeAlpha3;
        }
    }
}
