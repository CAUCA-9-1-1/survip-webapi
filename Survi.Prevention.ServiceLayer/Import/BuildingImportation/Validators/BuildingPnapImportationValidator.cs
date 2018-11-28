using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class BuildingPnapImportationValidator: AbstractValidator<BuildingPersonRequiringAssistance>
    {
	    public BuildingPnapImportationValidator()
	    {
		    RuleFor(m => m.Id)
			    .NotNullOrEmpty();

		    RuleFor(m => m.IdBuilding)
			    .RequiredKeyIsValid();

		    RuleFor(m => m.IdPersonRequiringAssistanceType)
			    .RequiredKeyIsValid();

		    RuleFor(m => m.ContactName)
			    .NotNullMaxLength(60);

		    RuleFor(m => m.ContactPhoneNumber)
			    .NotNullMaxLength(10);

		    RuleFor(m => m.Description)
			    .NotNull().WithMessage("{PropertyName}_NullValue");

		    RuleFor(m => m.Floor)
			    .NotNullMaxLength(3);

		    RuleFor(m => m.Local)
			    .NotNullMaxLength(10);

		    RuleFor(m => m.PersonName)
			    .NotNullMaxLength(60);   

		    RuleFor(m => m.DayResidentCount)
			    .GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");

		    RuleFor(m => m.EveningResidentCount)
			    .GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");
			
		    RuleFor(m => m.NightResidentCount)
			    .GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");
	    }
    }
}
