using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks
{
    public class BaseLocalizableEntityConverterMock 
        : BaseLocalizableEntityConverter<
            ApiClient.DataTransferObjects.Country, 
            Models.FireSafetyDepartments.Country, 
            CountryLocalization>
    {
        public bool LocalizationFieldsAreBeingCopied { get; set; }

        public BaseLocalizableEntityConverterMock(
            IManagementContext context, 
            AbstractValidator<ApiClient.DataTransferObjects.Country> validator) 
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ApiClient.DataTransferObjects.Country importedObject, 
            Models.FireSafetyDepartments.Country entity)
        {            
        }

        protected override void CopyLocalizationFields(
            ApiClient.DataTransferObjects.Country importedObject,
            Models.FireSafetyDepartments.Country entity)
        {
            LocalizationFieldsAreBeingCopied = true;
            base.CopyLocalizationFields(importedObject, entity);
        }

        public void CopyField(ApiClient.DataTransferObjects.Country importedObject,
            Models.FireSafetyDepartments.Country entity)
        {
            CopyImportedFieldsToEntity(importedObject, entity);
        }
    }
}
