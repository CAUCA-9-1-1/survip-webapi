﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingPersonRequiringAssistanceService : BaseCrudService<BuildingPersonRequiringAssistance>
	{
		public InspectionBuildingPersonRequiringAssistanceService(ManagementContext context) : base(context)
		{
		}

		public override BuildingPersonRequiringAssistance Get(Guid id)
		{
			var entity = Context.BuildingPersonsRequiringAssistance.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}

		public override List<BuildingPersonRequiringAssistance> GetList()
		{
			throw new NotImplementedException();
		}

		public List<BuildingPersonRequiringAssistanceForList> GetListLocalized(string languageCode, Guid idBuilding)
		{
			var query =
				from person in Context.BuildingPersonsRequiringAssistance.AsNoTracking()
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