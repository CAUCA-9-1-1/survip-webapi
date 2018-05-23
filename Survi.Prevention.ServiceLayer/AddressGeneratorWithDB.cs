using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using System;
using System.Linq;

namespace Survi.Prevention.ServiceLayer
{
    public class AddressGeneratorWithDb
    {
		public string GenerateAddressFromLanes(ManagementContext context, Guid? idLane, Guid? idIntersection, string languageCode)
		{
			var laneName = idLane.HasValue ? GetLaneLocalizedName(context, idLane.Value, languageCode) : "?";
			var interName = idIntersection.HasValue ? GetLaneLocalizedName(context, idIntersection.Value, languageCode) : "?";

			return $"{laneName} / {interName}";
		}
		public string GetLaneLocalizedName(ManagementContext context, Guid laneId, string languageCode)
		{
			var query =
				from lane in context.Lanes.AsNoTracking()
				where lane.Id == laneId && lane.IsActive
				let genericCode = lane.LaneGenericCode
				let publicCode = lane.PublicCode
				from localization in lane.Localizations.DefaultIfEmpty()
				where localization.IsActive && localization.LanguageCode == languageCode
				select new { localization.Name, genericDescription = genericCode.Description, genericCode.AddWhiteSpaceAfter, publicDescription = publicCode.Description };

			var laneFound = query.SingleOrDefault();

			if (laneFound == null)
				return null;
			return new LocalizedLaneNameGenerator()
				.GenerateLaneName(laneFound.Name, laneFound.genericDescription, laneFound.publicDescription, laneFound.AddWhiteSpaceAfter);
		}
	}
}
