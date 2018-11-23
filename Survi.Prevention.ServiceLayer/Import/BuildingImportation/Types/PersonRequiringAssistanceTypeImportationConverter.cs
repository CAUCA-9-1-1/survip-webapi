using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
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
            AbstractValidator<PersonRequiringAssistanceType> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            PersonRequiringAssistanceType importedObject,
            Models.Buildings.PersonRequiringAssistanceType entity)
        { }
    }
}