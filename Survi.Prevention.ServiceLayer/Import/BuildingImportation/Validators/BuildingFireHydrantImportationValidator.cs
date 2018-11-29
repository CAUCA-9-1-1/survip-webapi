using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class BuildingFireHydrantImportationValidator :
        AbstractValidator<BuildingFireHydrant>
    {
        public BuildingFireHydrantImportationValidator()
        {
            RuleFor(m => m.Id).NotNullOrEmpty();
            RuleFor(m => m.IdBuilding).RequiredKeyIsValid();
            RuleFor(m => m.IdFireHydrant).RequiredKeyIsValid();
        }
    }
}