using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class BuildingAlarmPanelImportationValidator :
        AbstractValidator<BuildingAlarmPanel>
    {
        public BuildingAlarmPanelImportationValidator()
        {
            RuleFor(m => m.Id)
                .NotNullOrEmpty();
            RuleFor(m => m.IdAlarmPanelType)
                .RequiredKeyIsValid();
            RuleFor(m => m.IdBuilding)
                .RequiredKeyIsValid();
            RuleFor(m => m.Floor)
                .MaximumLength(3);
            RuleFor(m => m.Wall)
                .MaximumLength(15);
            RuleFor(m => m.Sector)
                .MaximumLength(15);
        }
    }
}