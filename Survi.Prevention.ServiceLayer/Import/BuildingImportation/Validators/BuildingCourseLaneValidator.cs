using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    internal class BuildingCourseLaneValidator : 
        AbstractValidator<BuildingCourseLane>
    {
        public BuildingCourseLaneValidator()
        {
            RuleFor(m => m.Direction).IsInEnum().WithMessage("{PropertyName}_InvalidValue");
            RuleFor(m => m.Sequence).GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InvalidValue");
            RuleFor(m => m.IdLane).RequiredKeyIsValid();
        }
    }
}