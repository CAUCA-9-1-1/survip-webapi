
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Survi.Prevention.ServiceLayer
{
    public class FormatFluentValidationErrorsToStringList
    {
	    public List<string> GetFluentValidationErrorList(List<ValidationFailure> errorFailures)
	    {
			List<string> errorList = new List<string>();
		    errorFailures.ForEach(error =>errorList.Add(error.ErrorCode+" | "+error.ErrorMessage));
		    return errorList;
	    }
    }
}
