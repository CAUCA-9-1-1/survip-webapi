using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using Imported = Survi.Prevention.ApiClient.DataTransferObjects;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks
{
    public class BaseLocalizableEntityConverterMock 
        : BaseLocalizableEntityConverter<Imported.Country, Country, CountryLocalization>
    {
        public bool LocalizationFieldsAreBeingCopied { get; set; }

        public BaseLocalizableEntityConverterMock(
            IManagementContext context, 
            AbstractValidator<Imported.Country> validator) 
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(Imported.Country importedObject, Country entity)
        {            
        }

        protected override void CopyLocalizationFields(Imported.Country importedObject, Country entity)
        {
            LocalizationFieldsAreBeingCopied = true;
            base.CopyLocalizationFields(importedObject, entity);
        }

        public void CopyField(Imported.Country importedObject, Country entity)
        {
            CopyImportedFieldsToEntity(importedObject, entity);
        }
    }
}
