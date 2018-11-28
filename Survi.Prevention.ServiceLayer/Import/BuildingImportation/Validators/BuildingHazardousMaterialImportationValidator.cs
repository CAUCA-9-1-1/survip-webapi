using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
	public class BuildingHazardousMaterialImportationValidator : AbstractValidator<BuildingHazardousMaterial>
	{
		public BuildingHazardousMaterialImportationValidator()
		{
			RuleFor(m => m.Id)
				.NotNullOrEmpty();

			RuleFor(m => m.IdBuilding)
				.RequiredKeyIsValid();

			RuleFor(m => m.IdHazardousMaterial)
				.RequiredKeyIsValid();

			RuleFor(m => m.IdUnitOfMeasure)
				.RequiredKeyIsValid()
				.When(IsContainerCapacityImplemented);
			
			RuleFor(m => m.CapacityContainer)
				.GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");

			RuleFor(m => m.Quantity)
				.GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");

			RuleFor(m => m.TankType)
				.IsInEnum();

			RuleFor(m => m.Container)
				.NotNullMaxLength(100);

			RuleFor(m => m.Floor)
				.NotNullMaxLength(4);

			RuleFor(m => m.GasInlet)
				.NotNullMaxLength(100);

			RuleFor(m => m.Place)
				.NotNullMaxLength(150);

			RuleFor(m => m.Sector)
				.NotNullMaxLength(15);

			RuleFor(m => m.SupplyLine)
				.NotNullMaxLength(50);

			RuleFor(m => m.SecurityPerimeter)
				.NotNull().WithMessage("{PropertyName}_NullValue");

			RuleFor(m => m.OtherInformation)
				.NotNull().WithMessage("{PropertyName}_NullValue");

			RuleFor(m => m.SupplyLine)
				.NotNullMaxLength(50);

			RuleFor(m => m.Wall)
				.NotNullMaxLength(15);            
		}

		private bool IsContainerCapacityImplemented(BuildingHazardousMaterial arg) => arg.CapacityContainer > 0;
	}
}
