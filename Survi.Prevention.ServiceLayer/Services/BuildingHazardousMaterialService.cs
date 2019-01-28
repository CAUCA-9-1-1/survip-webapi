using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using StorageTankType = Survi.Prevention.ApiClient.DataTransferObjects.StorageTankType;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingHazardousMaterialService : BaseCrudServiceWithImportation<BuildingHazardousMaterial, ApiClient.DataTransferObjects.BuildingHazardousMaterial>
	{
		public BuildingHazardousMaterialService(
			IManagementContext context, 
			IEntityConverter<ApiClient.DataTransferObjects.BuildingHazardousMaterial, BuildingHazardousMaterial> converter) 
			: base(context, converter)
		{
		}

		public override BuildingHazardousMaterial Get(Guid id)
		{
			return Context.BuildingHazardousMaterials.AsNoTracking()
                .FirstOrDefault(material => material.Id == id);
		}

        public List<BuildingHazardousMaterial> GetBuildingHazardousMaterialList(Guid idBuilding)
		{
            var result = Context.BuildingHazardousMaterials
                .Where(c => c.IdBuilding == idBuilding)
                .ToList();

			return result;
		}

		public List<BuildingHazardousMaterialForList> GetMaterialsForList(Guid idBuilding, string languageCode)
		{
			var query =
				from matBuilding in Context.BuildingHazardousMaterials.AsNoTracking()
				where matBuilding.IdBuilding == idBuilding && matBuilding.IsActive
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

        public List<ApiClient.DataTransferObjects.BuildingHazardousMaterial> Export(List<string> idBuildings)
        {
            var query =
                from buildingHazardousMaterial in Context.BuildingHazardousMaterials.AsNoTracking()
                    .IgnoreQueryFilters()
                where buildingHazardousMaterial.HasBeenModified &&
                      idBuildings.Contains(buildingHazardousMaterial.IdBuilding.ToString())
                select new ApiClient.DataTransferObjects.BuildingHazardousMaterial
                {
                    Id = buildingHazardousMaterial.IdExtern,
                    CapacityContainer = buildingHazardousMaterial.CapacityContainer,
                    Container = buildingHazardousMaterial.Container,
                    IdBuilding = buildingHazardousMaterial.Building.IdExtern,
                    Floor = buildingHazardousMaterial.Floor,
                    GasInlet = buildingHazardousMaterial.GasInlet,
                    IdHazardousMaterial = buildingHazardousMaterial.Material.IdExtern,
                    IdUnitOfMeasure = buildingHazardousMaterial.Unit.IdExtern,
                    OtherInformation = buildingHazardousMaterial.OtherInformation,
                    Place = buildingHazardousMaterial.Place,
                    Quantity = buildingHazardousMaterial.Quantity,
                    Sector = buildingHazardousMaterial.Sector,
                    SecurityPerimeter = buildingHazardousMaterial.SecurityPerimeter,
                    SupplyLine = buildingHazardousMaterial.SupplyLine,
                    TankType = (StorageTankType) buildingHazardousMaterial.TankType,
                    Wall = buildingHazardousMaterial.Wall,
                    IsActive = buildingHazardousMaterial.IsActive,
                    LastEditedOn = buildingHazardousMaterial.LastModifiedOn

                };

            return query.ToList();
        }
    }
}