using FluentValidation;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
	public class UtilisationCodeImportationValidator : AbstractValidator<ApiClient.DataTransferObjects.UtilisationCode>
    {
        public UtilisationCodeImportationValidator()
        {
            RuleFor(m => m.Id)
                .NotNullOrEmpty();

            RuleFor(m => m.Localizations)
                .NotNull().WithMessage("{PropertyName}_NullValue")
                .Must(new BaseLocalizationValidator().HaveRequiredLocalizationCount)
                .WithMessage("{PropertyName}_InvalidCount")
                .Must(new BaseLocalizationValidator().HaveRequiredLanguages).WithMessage("{PropertyName}_InvalidValue");

            RuleFor(m => m.Cubf).NotNullOrEmptyWithMaxLength(5);
            RuleFor(m => m.Scian).NotNullMaxLength(25);
	        RuleFor(m => m.Year)
				.GreaterThan(2000)
		        .LessThan(2100);
		}
    }
}