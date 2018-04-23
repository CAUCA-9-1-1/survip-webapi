using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingFireHydrantService : BaseService
	{
		public InspectionBuildingFireHydrantService(ManagementContext context) : base(context)
		{
		}

		public List<InspectionBuildingFireHydrantForList> GetFormFireHydrants(Guid inspectionId, string languageCode)
		{
			var results = (
				from inspection in Context.Inspections.AsNoTracking()
				where inspection.Id == inspectionId
				from formHydrant in inspection.MainBuilding.FireHydrants
				where formHydrant.IsActive
				let hydrant = formHydrant.Hydrant
				select new
				{
					formHydrant.Id,
					hydrant.Number,
					hydrant.IdLane,
					hydrant.IdIntersection,
					hydrant.PhysicalPosition,
					hydrant.LocationType,
					hydrant.Coordinates
				}).ToList();

			return results
				.Select(hydrant => new InspectionBuildingFireHydrantForList
				{
					Id = hydrant.Id,
					IdInspection = inspectionId,
					Number = hydrant.Number,
					Address = GenerateAddress(hydrant.LocationType, hydrant.IdLane, hydrant.IdIntersection, hydrant.PhysicalPosition, hydrant.Coordinates, languageCode)

				}).ToList();
		}

		private string GenerateAddress(FireHydrantLocationType type, Guid? idLane, Guid? idIntersection, string physicalPosition, string coordinate, string languageCode)
		{
			if (type == FireHydrantLocationType.Text)
				return physicalPosition;
			if (type == FireHydrantLocationType.Coordinates)
				return coordinate;
			if (type == FireHydrantLocationType.LaneAndIntersection)
				return GenerateAddressFromLanes(idLane, idIntersection, languageCode);
			
			return "";
		}

		private string GenerateAddressFromLanes(Guid? idLane, Guid? idIntersection, string languageCode)
		{
			var laneName = idLane.HasValue ? GetLaneName(idLane.Value, languageCode) : "?";
			var interName = idIntersection.HasValue ? GetLaneName(idIntersection.Value, languageCode) : "?";

			return $"{laneName} / {interName}";
		}

		private string GetLaneName(Guid idLane, string languageCode)
		{
			var laneFound = (
					from lane in Context.Lanes.AsNoTracking()
					where lane.Id == idLane
					from loc in lane.Localizations
					where loc.IsActive && loc.LanguageCode == languageCode
					let gen = lane.LaneGenericCode
					let pub = lane.PublicCode
					select new {loc.Name, genDescription = gen.Description, pubDescription = pub.Description, gen.AddWhiteSpaceAfter})
				.SingleOrDefault();
			if (laneFound != null)
				return new LocalizedLaneNameGenerator().GenerateLaneName(laneFound.Name, laneFound.genDescription, laneFound.pubDescription, laneFound.AddWhiteSpaceAfter);
			return "";
		}
	}
}