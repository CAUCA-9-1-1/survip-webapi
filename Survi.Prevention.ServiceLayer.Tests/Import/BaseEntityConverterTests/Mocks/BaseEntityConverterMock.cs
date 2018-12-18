using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Imported = Survi.Prevention.ApiClient.DataTransferObjects;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks
{
    public class BaseEntityConverterMock : BaseEntityConverter<Imported.Country, Country>
    {
        public bool CustomFieldsHaveBeenCopied { get; set; }
        public bool HasCreateANewCountry { get; set; }
        public bool HasUsedAnExistingCountry { get; set; }

        public BaseEntityConverterMock(IManagementContext context, AbstractValidator<Imported.Country> validator)
            : base(context, validator, null, new CacheSystem())
        {
        }

        protected override void CopyCustomFieldsToEntity(Imported.Country importedObject, Country entity)
        {
            CustomFieldsHaveBeenCopied = true;
        }

        protected override Country GetEntityFromDatabase(string externalId)
        {
            var country = base.GetEntityFromDatabase(externalId);
            HasUsedAnExistingCountry = country != null;
            return country;
        }

        protected override Country CreateNew()
        {
            HasCreateANewCountry = true;
            return base.CreateNew();
        }
    }
}