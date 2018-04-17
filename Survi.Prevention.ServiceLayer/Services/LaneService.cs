using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class LaneService : BaseCrudService<Lane>
	{
		public LaneService(ManagementContext context) : base(context)
		{
		}

		public override Lane Get(Guid id)
		{
			var result = Context.Lanes
				.Include(s => s.Localizations)
				.First(s => s.Id == id);

			return result;
		}

		public override List<Lane> GetList()
		{
			var result = Context.Lanes
				.Include(s => s.Localizations)
				.ToList();

			return result;
		}

		public List<LaneLocalized> GetListLocalized(Guid cityId, string languageCode)
		{
			var query =
				from lane in Context.Lanes.AsNoTracking()
				where lane.IdCity == cityId && lane.IsActive
				let genericCode = lane.LaneGenericCode
				let publicCode = lane.PublicCode
				from localization in lane.Localizations.DefaultIfEmpty()
				where localization.IsActive && localization.LanguageCode == languageCode
				select new {lane.Id, localization.Name, genericDescription = genericCode.Description, genericCode.AddWhiteSpaceAfter, publicDescription = publicCode.Description};

			var result = query.ToList()
				.Select(lane => new LaneLocalized {Id = lane.Id, Name = new LocalizedLaneNameGenerator().GenerateLaneName(lane.Name, lane.genericDescription, lane.publicDescription, lane.AddWhiteSpaceAfter)})
				.ToList();

			return result;
		}
	}
}