using System;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class BuildingDetailImportationValidator :
        AbstractValidator<BuildingDetail>
    {
        public BuildingDetailImportationValidator()
        {
            RuleFor(m => m.IdBuilding)
                .RequiredKeyIsValid();

            RuleFor(m => m.IdUnitOfMeasureEstimatedWaterFlow)
                .RequiredKeyIsValid()
                .When(m => m.EstimatedWaterFlow > 0);

            RuleFor(m => m.IdUnitOfMeasureHeight)
                .RequiredKeyIsValid()
                .When(m => m.Height > 0);

            RuleFor(m => m.IdUnitOfMeasureEstimatedWaterFlow)
                .OptionalKeyIsNullOrValid()
                .When(m => m.EstimatedWaterFlow <= 0);

            RuleFor(m => m.IdUnitOfMeasureHeight)
                .OptionalKeyIsNullOrValid()
                .When(m => m.Height <= 0);

            RuleFor(m => m.GarageType)
                .Must(type => Enum.IsDefined(typeof(GarageType), type))
                .WithMessage("{PropertyName}_InvalidValue");

            RuleFor(m => m.MimeType)
                .NotNullOrEmpty()
                .When(m => m.PictureData != null);
        }
    }
}