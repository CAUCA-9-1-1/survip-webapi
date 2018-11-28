using System;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class BuildingParticularRiskImportationValidator :
        AbstractValidator<BuildingParticularRisk>
    {
        public BuildingParticularRiskImportationValidator()
        {
            RuleFor(m => m.Id)
                .NotNullOrEmpty();
            RuleFor(m => m.RiskType)
                .Must(type => Enum.IsDefined(typeof(ParticularRiskType), type))
                .WithMessage("{PropertyName}_InvalidValue");
            RuleFor(m => m.IdBuilding)
                .RequiredKeyIsValid();
            RuleFor(m => m.Dimension)
                .MaximumLength(100);
            RuleFor(m => m.Wall)
                .MaximumLength(3);
            RuleFor(m => m.Sector)
                .MaximumLength(3);
        }
    }
}