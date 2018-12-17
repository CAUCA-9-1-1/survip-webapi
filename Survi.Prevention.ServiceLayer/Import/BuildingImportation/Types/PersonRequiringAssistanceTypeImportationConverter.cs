using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using PersonRequiringAssistanceType = Survi.Prevention.ApiClient.DataTransferObjects.PersonRequiringAssistanceType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Types
{
    public class PersonRequiringAssistanceTypeImportationConverter
        : BaseLocalizableEntityConverter<
            PersonRequiringAssistanceType,
            Models.Buildings.PersonRequiringAssistanceType,
            PersonRequiringAssistanceTypeLocalization>
    {
        public PersonRequiringAssistanceTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<PersonRequiringAssistanceType> validator, CacheSystem cache)
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            PersonRequiringAssistanceType importedObject,
            Models.Buildings.PersonRequiringAssistanceType entity)
        { }
    }
}