using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingHazardousMaterialService : BaseCrudService<BuildingHazardousMaterial>
	{
		public InspectionBuildingHazardousMaterialService(ManagementContext context) : base(context)
		{
		}

		public override BuildingHazardousMaterial Get(Guid id)
		{
			var entity = Context.BuildingHazardousMaterials.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}

		public override List<BuildingHazardousMaterial> GetList()
		{
			throw new NotImplementedException();
		}

		public List<BuildingHazardousMaterialForList> GetListLocalized(string languageCode, Guid idBuilding)
		{
			var query =
				from matBuilding in Context.BuildingHazardousMaterials.AsNoTracking()
				where matBuilding.IdBuilding == idBuilding && matBuilding.IsActive
				let mat = matBuilding.Material
				from loc in mat.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new
				{
					Id = matBuilding.Id,
					Name = loc.Name,
					Quantity = matBuilding.Quantity,
					matBuilding.CapacityContainer,
					abbreviation = matBuilding.Unit == null ? null : matBuilding.Unit.Abbreviation,
					unitName = matBuilding.Unit == null ? "" :
						matBuilding.Unit.Localizations
							.Where(locUnit => locUnit.IsActive && locUnit.LanguageCode == languageCode)
							.Select(locUnit => locUnit.Name)
							.FirstOrDefault()
				};

			var result = query
				.ToList()
				.Select(mat => new BuildingHazardousMaterialForList
				{
					Id = mat.Id,
					HazardousMaterialName = mat.Name,
					QuantityDescription = GetQuantityDescription(mat.Quantity, mat.CapacityContainer, mat.abbreviation??mat.unitName)
				});

			return result.ToList();
		}

		private string GetQuantityDescription(int quantity, decimal capacityContainer, string abbreviation)
		{
			var quantityDescription = "";
			if (capacityContainer > 0)
			{
				quantityDescription = capacityContainer.ToString("G26");
				if (!string.IsNullOrWhiteSpace(abbreviation))
					quantityDescription += " " + abbreviation;

				if (quantity > 0)
					quantityDescription = $"{quantity} x {quantityDescription}";
			}

			return quantityDescription;
		}
	}

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