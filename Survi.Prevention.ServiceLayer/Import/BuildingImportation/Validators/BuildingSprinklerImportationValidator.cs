using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class BuildingSprinklerImportationValidator
        : AbstractValidator<BuildingSprinkler>
    {
        public BuildingSprinklerImportationValidator()
        {
            RuleFor(m => m.Id)
                .NotNullOrEmpty();
            RuleFor(m => m.IdSprinklerType)
                .RequiredKeyIsValid();
            RuleFor(m => m.IdBuilding)
                .RequiredKeyIsValid();
            RuleFor(m => m.Floor)
                .MaximumLength(3);
            RuleFor(m => m.Wall)
                .MaximumLength(15);
            RuleFor(m => m.Sector)
                .MaximumLength(15);
            RuleFor(m => m.PipeLocation)
                .MaximumLength(500);
            RuleFor(m => m.CollectorLocation)
                .MaximumLength(500);
        }
    }
}