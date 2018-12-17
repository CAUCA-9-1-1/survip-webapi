using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using importedBuildingContact = Survi.Prevention.ApiClient.DataTransferObjects.BuildingContact;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingContactImportationConverter: BaseEntityConverter<importedBuildingContact, BuildingContact>
    {
	    public BuildingContactImportationConverter(IManagementContext context, AbstractValidator<importedBuildingContact> validator, CacheSystem cache)
	        : base(context, validator, null, cache)
        {
	    }

	    protected override void CopyCustomFieldsToEntity(importedBuildingContact importedObject, BuildingContact entity)
	    {
		    entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
		    entity.FirstName = importedObject.FirstName;
		    entity.LastName = importedObject.LastName;
		    entity.CallPriority = importedObject.CallPriority;
		    entity.IsOwner = importedObject.IsOwner;
		    entity.PhoneNumber = importedObject.PhoneNumber;
		    entity.PhoneNumberExtension = importedObject.PhoneNumberExtension;
		    entity.PagerNumber = importedObject.PagerNumber;
		    entity.PagerCode = importedObject.PagerCode;
		    entity.CellphoneNumber = importedObject.CellphoneNumber;
		    entity.OtherNumber = importedObject.OtherNumber;
		    entity.OtherNumberExtension = importedObject.OtherNumberExtension;
	    }

	    protected override void GetRealForeignKeys(importedBuildingContact importedObject)
	    {
		    importedObject.IdBuilding = GetRealId<Building>(importedObject.IdBuilding);
	    }
    }
}
