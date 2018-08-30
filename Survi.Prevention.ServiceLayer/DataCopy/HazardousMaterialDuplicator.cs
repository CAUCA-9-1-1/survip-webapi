using System.Collections.Generic;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class HazardousMaterialDuplicator
	{
		public TCopy Duplicate<TOriginal, TCopy>(TOriginal material)
			where TOriginal : IBaseBuildingHazardousMaterial, new()
			where TCopy : IBaseBuildingHazardousMaterial, new()
		{
			return new TCopy
			{
				CapacityContainer = material.CapacityContainer,
				Container = material.Container,
				CreatedOn = material.CreatedOn,
				Floor = material.Floor,
				GasInlet = material.GasInlet,
				Id = material.Id,
				IdBuilding = material.IdBuilding,
				IdHazardousMaterial = material.IdHazardousMaterial,
				IdUnitOfMeasure = material.IdUnitOfMeasure,
				IsActive = material.IsActive,
				OtherInformation = material.OtherInformation,
				Place = material.Place,
				Quantity = material.Quantity,
				Sector = material.Sector,
				SecurityPerimeter = material.SecurityPerimeter,
				SupplyLine = material.SupplyLine,
				TankType = material.TankType,
				Wall = material.Wall
			};
		}

		public IEnumerable<TCopy> Duplicate<TOriginal, TCopy>(ICollection<TOriginal> materials)
			where TOriginal : IBaseBuildingHazardousMaterial, new()
			where TCopy : IBaseBuildingHazardousMaterial, new()
		{
			foreach (var material in materials)
				yield return Duplicate<TOriginal, TCopy>(material);
		}
	}
}