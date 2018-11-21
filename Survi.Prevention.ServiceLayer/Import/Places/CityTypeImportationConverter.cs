using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedCityType = Survi.Prevention.ApiClient.DataTransferObjects.CityType;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CityTypeImportationConverter: BaseLocalizableEntityConverter<importedCityType, CityType, CityTypeLocalization>
    {
	    public CityTypeImportationConverter(IManagementContext context, AbstractValidator<importedCityType> validator) : base(context, validator)
	    {
	    }

	    protected override void CopyCustomFieldsToEntity(importedCityType importedObject, CityType entity)
	    {
	    }
    }
}
