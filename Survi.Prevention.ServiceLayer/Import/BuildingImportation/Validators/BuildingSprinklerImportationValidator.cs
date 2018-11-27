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
                .MaxLength(100);
            RuleFor(m => m.Wall)
                .MaxLength(100);
            RuleFor(m => m.Sector)
                .MaxLength(100);
            RuleFor(m => m.PipeLocation)
                .MaxLength(500);
            RuleFor(m => m.CollectorLocation)
                .MaxLength(500);
        }
    }
}