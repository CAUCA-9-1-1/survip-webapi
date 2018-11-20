using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingHazardousMaterialService : BaseCrudService<InspectionBuildingHazardousMaterial>
	{
		public InspectionBuildingHazardousMaterialService(IManagementContext context) : base(context)
		{
		}

		public override InspectionBuildingHazardousMaterial Get(Guid id)
		{
			var entity = Context.InspectionBuildingHazardousMaterials.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}
		
		public List<InspectionBuildingHazardousMaterial> GetList(Guid idBuilding)
		{
			return Context.InspectionBuildingHazardousMaterials.AsNoTracking()
				.Where(mat => mat.IdBuilding == idBuilding)
				.ToList();
		}

		public List<BuildingHazardousMaterialForList> GetListLocalized(Guid buildingId, string languageCode)
		{
			var query =
				from matBuilding in Context.InspectionBuildingHazardousMaterials.AsNoTracking()
				where matBuilding.IdBuilding == buildingId && matBuilding.IsActive
				let mat = matBuilding.Material
				from loc in mat.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new
				{
					matBuilding.Id,
					loc.Name,
					matNumber = mat.Number,
					matBuilding.Quantity,
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
					HazardousMaterialNumber = mat.matNumber,
					HazardousMaterialName = mat.Name,
					QuantityDescription = GetQuantityDescription(mat.Quantity, mat.CapacityContainer, mat.abbreviation ?? mat.unitName)
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
}