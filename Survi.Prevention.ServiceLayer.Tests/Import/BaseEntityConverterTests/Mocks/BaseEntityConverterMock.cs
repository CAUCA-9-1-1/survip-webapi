using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks
{
    public class BaseEntityConverterMock : BaseEntityConverter<ApiClient.DataTransferObjects.Country, Models.FireSafetyDepartments.Country>
    {
        public bool CustomFieldsHaveBeenCopied { get; set; }
        public bool HasCreateANewCountry { get; set; }
        public bool HasUsedAnExistingCountry { get; set; }

        public BaseEntityConverterMock(IManagementContext context, AbstractValidator<ApiClient.DataTransferObjects.Country> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(ApiClient.DataTransferObjects.Country importedObject, Models.FireSafetyDepartments.Country entity)
        {
            CustomFieldsHaveBeenCopied = true;
        }

        protected override Models.FireSafetyDepartments.Country GetEntityFromDatabase(string externalId)
        {
            var country = base.GetEntityFromDatabase(externalId);
            HasUsedAnExistingCountry = country != null;
            return country;
        }

        protected override Models.FireSafetyDepartments.Country CreateNew()
        {
            HasCreateANewCountry = true;
            return base.CreateNew();
        }
    }
}