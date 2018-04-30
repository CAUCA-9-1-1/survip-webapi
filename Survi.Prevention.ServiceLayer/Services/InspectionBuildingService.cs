﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingService : BaseService
	{
		public InspectionBuildingService(ManagementContext context) : base(context)
		{
		}

		public List<InspectionBuildingForList> GetBuildings(Guid inspectionId, string languageCode)
		{
			var results = (
				from inspection in Context.Inspections.AsNoTracking()
				where inspection.Id == inspectionId && inspection.IsActive
				from building in Context.Buildings.AsNoTracking()
				where (building.IdParentBuilding == inspection.IdBuilding || building.Id == inspection.IdBuilding) && building.IsActive
				from loc in building.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new
				{
					building.Id,
					loc.Name,
					building.Picture.Data
				}).ToList();

			return results
				.Select(building => new InspectionBuildingForList
				{
					Id = building.Id,
					IdInspection = inspectionId,
					Name = building.Name,
					Picture = building.Data == null ? null : Convert.ToBase64String(building.Data)
				}).ToList();
		}
	}
}