using System;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.FireHydrantImportation.Validators
{
    public class UnitOfMeasureImportationValidator
        : BaseImportValidator<UnitOfMeasure>
    {
        public UnitOfMeasureImportationValidator()
        {
            RuleFor(unit => unit.Abbreviation).NotNullOrEmptyWithMaxLength(5);
            RuleFor(unit => unit.MeasureType)
                .Must(value => Enum.IsDefined(typeof(MeasureType), value))
                .WithMessage("{PropertyName}_InvalidType");
        }
    }
}