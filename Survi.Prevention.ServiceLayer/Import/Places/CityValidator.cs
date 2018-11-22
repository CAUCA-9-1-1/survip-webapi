﻿using Survi.Prevention.ServiceLayer.ValidationUtilities;

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
			    .NotNullOrEmpty();

		    RuleFor(m => m.IdCityType)
			    .NotNullOrEmpty();

	    }
    }
}
