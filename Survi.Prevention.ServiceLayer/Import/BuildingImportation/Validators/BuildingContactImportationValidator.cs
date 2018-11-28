using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
	public class BuildingContactImportationValidator : AbstractValidator<BuildingContact>
	{
		public BuildingContactImportationValidator()
		{
			RuleFor(m => m.Id)
				.NotNullOrEmpty();

			RuleFor(m => m.IdBuilding)
				.NotNullOrEmpty();

			RuleFor(m => m.FirstName)
				.NotNullOrEmptyWithMaxLength(30);

			RuleFor(m => m.LastName)
				.NotNullOrEmptyWithMaxLength(30);

			RuleFor(m => m.CallPriority)
				.GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");

			RuleFor(m => m.PhoneNumber)
				.NotNullOrEmptyWithMaxLength(10);

			RuleFor(m => m.PhoneNumber)
				.MinimumLength(10)
				.When(m => !string.IsNullOrEmpty(m.PhoneNumber));

			RuleFor(m => m.PhoneNumberExtension)
				.NotNullMaxLength(10);

			RuleFor(m => m.PagerNumber)
				.NotNullMaxLength(10);

			RuleFor(m => m.PagerCode)
				.NotNullMaxLength(10);

			RuleFor(m => m.CellphoneNumber)
				.NotNullMaxLength(10);

			RuleFor(m => m.CellphoneNumber)
				.MinimumLength(10)
				.When(m => !string.IsNullOrEmpty(m.CellphoneNumber));

			RuleFor(m => m.OtherNumber)
				.NotNullMaxLength(10);

			RuleFor(m => m.OtherNumber)
				.MinimumLength(10)
				.When(m => !string.IsNullOrEmpty(m.OtherNumber));

			RuleFor(m => m.OtherNumberExtension)
				.NotNullMaxLength(10);
		}

	}
}
