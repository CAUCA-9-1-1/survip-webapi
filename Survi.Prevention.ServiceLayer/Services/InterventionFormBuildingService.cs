using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InterventionFormBuildingService : BaseService
	{
		public InterventionFormBuildingService(ManagementContext context) : base(context)
		{
		}

		public List<InterventionFormBuildingForList> GetFormBuildings(Guid interventionFormId, string languageCode)
		{
			var results = (
				from formBuilding in Context.InterventionFormBuildings.AsNoTracking()
				where formBuilding.IdInterventionForm == interventionFormId && formBuilding.IsActive
				let building = formBuilding.Building
				from loc in building.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new
				{
					formBuilding.Id,
					formBuilding.IdBuilding,
					formBuilding.IdInterventionForm,
					loc.Name,
					formBuilding.Picture.Data
				}).ToList();

			return results
				.Select(building => new InterventionFormBuildingForList
				{
					Id = building.Id,
					IdBuilding = building.IdBuilding,
					IdInterventionForm = building.IdInterventionForm,
					Name = building.Name,
					Picture = building.Data == null ? null : Base64UrlEncoder.Decode(Convert.ToBase64String(building.Data))
				}).ToList();
		}
	}
}
