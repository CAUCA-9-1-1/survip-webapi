using System.Collections.Generic;
using FluentValidation.Results;

namespace Survi.Prevention.ServiceLayer.ValidationUtilities
{
    public class FluentValidationErrorFormatter
    {
	    public List<string> GetFluentValidationErrorList(List<ValidationFailure> errorFailures)
	    {
			List<string> errorList = new List<string>();
		    errorFailures.ForEach(error =>errorList.Add(error.ErrorMessage));
		    return errorList;
	    }
    }
}
