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
            RuleFor(m => m.IdAlarmPanelType)
                .RequiredKeyIsValid();
            RuleFor(m => m.IdBuilding)
                .RequiredKeyIsValid();

            RuleFor(m => m.Floor)
                .MaxLength(100);
            RuleFor(m => m.Wall)
                .MaxLength(100);
            RuleFor(m => m.Sector)
                .MaxLength(100);
        }
    }
}