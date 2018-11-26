using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class BuildingAnomalyImportationValidator :
        AbstractValidator<BuildingAnomaly>
    {
        public BuildingAnomalyImportationValidator()
        {
            RuleFor(m => m.IdBuilding)
                .RequiredKeyIsValid();
            RuleFor(m => m.Theme)
                .NotNullOrEmptyWithMaxLength(50);
            RuleFor(m => m.Notes)
                .NotNullOrEmpty();
        }
    }
}