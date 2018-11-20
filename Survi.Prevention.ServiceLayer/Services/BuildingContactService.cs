using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingContactService : BaseCrudService<BuildingContact>
	{
		public BuildingContactService(IManagementContext context) : base(context)
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