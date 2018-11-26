using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;

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
    }
}