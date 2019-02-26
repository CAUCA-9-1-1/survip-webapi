using FluentValidation;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
	public class CityValidator: BaseImportValidator<ApiClient.DataTransferObjects.City>
    {
	    public CityValidator()
	    {
		    RuleFor(m => m.Code)
			    .NotNullOrEmptyWithMaxLength(10);

		    RuleFor(m => m.Code3Letters)
			    .NotNullOrEmptyWithMaxLength(3);

		    RuleFor(m => m.IdCounty)
			    .RequiredKeyIsValid();

		    RuleFor(m => m.IdCityType)
			    .RequiredKeyIsValid();

		    RuleFor(m => m.UtilizationCodeYear)
			    .GreaterThan(2000)
			    .LessThan(2100);
	    }
    }
}
