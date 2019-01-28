using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingContactService : BaseCrudServiceWithImportation<BuildingContact, ApiClient.DataTransferObjects.BuildingContact>
	{
		public BuildingContactService(
			IManagementContext context, 
			IEntityConverter<ApiClient.DataTransferObjects.BuildingContact, BuildingContact> converter) 
			: base(context, converter)
		{
		}

		public override BuildingContact Get(Guid id)
		{
			return Context.BuildingContacts.AsNoTracking()
				.FirstOrDefault(contact => contact.Id == id);
		}

        public List<BuildingContact> GetBuildingContactList(Guid idBuilding)
		{
            var result = Context.BuildingContacts
                .Where(c => c.IdBuilding == idBuilding)
                .ToList();

			return result;
		}

        public List<ApiClient.DataTransferObjects.BuildingContact> Export(List<string> idBuildings)
        {
            var query = (
                from buildingcontact in Context.BuildingContacts.AsNoTracking()
                    .IgnoreQueryFilters()
                where buildingcontact.HasBeenModified &&
                      idBuildings.Contains(buildingcontact.IdBuilding.ToString())
                select new ApiClient.DataTransferObjects.BuildingContact
                {
                    Id = buildingcontact.IdExtern,
                    IdBuilding = buildingcontact.Building.IdExtern,
                    CallPriority = buildingcontact.CallPriority,
                    CellphoneNumber = buildingcontact.CellphoneNumber,
                    FirstName = buildingcontact.FirstName,
                    IsOwner = buildingcontact.IsOwner,
                    LastName = buildingcontact.LastName,
                    OtherNumber = buildingcontact.OtherNumber,
                    OtherNumberExtension = buildingcontact.OtherNumberExtension,
                    PagerCode = buildingcontact.PagerCode,
                    PagerNumber = buildingcontact.PagerNumber,
                    PhoneNumber = buildingcontact.PhoneNumber,
                    PhoneNumberExtension = buildingcontact.PhoneNumberExtension,
                    IsActive = buildingcontact.IsActive,
                    LastEditedOn = buildingcontact.LastModifiedOn
                });
            return query.ToList();
        }
    }
}