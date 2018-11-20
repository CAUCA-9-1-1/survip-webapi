using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingPersonRequiringAssistanceService : BaseCrudService<InspectionBuildingPersonRequiringAssistance>
	{
		public InspectionBuildingPersonRequiringAssistanceService(IManagementContext context) : base(context)
		{
		}

		public override InspectionBuildingPersonRequiringAssistance Get(Guid id)
		{
			var entity = Context.InspectionBuildingPersonsRequiringAssistance.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}

		public List<InspectionBuildingPersonRequiringAssistance> GetList(Guid idBuilding)
		{
			return Context.InspectionBuildingPersonsRequiringAssistance.AsNoTracking()
				.Where(p => p.IdBuilding == idBuilding)
				.ToList();
		}
		
		public List<BuildingPersonRequiringAssistanceForList> GetListLocalized(string languageCode, Guid idBuilding)
		{
			var query =
				from person in Context.InspectionBuildingPersonsRequiringAssistance.AsNoTracking()
				where person.IdBuilding == idBuilding && person.IsActive
				let type = person.PersonType
				from loc in type.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new BuildingPersonRequiringAssistanceForList
				{
					Id = person.Id,
					Name = person.PersonName,
					TypeDescription = loc.Name
				};

			return query.ToList();
		}
	}
}