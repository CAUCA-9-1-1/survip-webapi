using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingContactService : BaseCrudService<BuildingContact>
	{
		public InspectionBuildingContactService(ManagementContext context) : base(context)
		{
		}

		public override BuildingContact Get(Guid id)
		{
			return Context.BuildingContacts.AsNoTracking()
				.FirstOrDefault(contact => contact.Id == id);
		}

		public List<BuildingContactForList> GetListLocalized(Guid idBuilding, string languageCode)
		{
			var query =
				from contact in Context.BuildingContacts.AsNoTracking()
				where contact.IsActive && contact.IdBuilding == idBuilding
				select new BuildingContactForList
				{
					Id = contact.Id,
					IsOwner = contact.IsOwner,
					Name = (string.IsNullOrWhiteSpace(contact.FirstName) ? "" :  contact.FirstName + " ") + (string.IsNullOrWhiteSpace(contact.LastName) ? "":  contact.LastName)
				};

			return query.ToList();
		}

		public override List<BuildingContact> GetList()
		{
			throw new NotImplementedException();			
		}
	}
}