using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class RiskLevelService : BaseService
	{
		public RiskLevelService(ManagementContext context) : base(context)
		{
		}

		public List<RiskLevelForWeb> GetRiskLevelsForWeb(string language)
		{
			var query =
				from riskLevel in Context.RiskLevels				
				where riskLevel.IsActive
				from localization in riskLevel.Localizations
				where localization.LanguageCode == language
				select new RiskLevelForWeb
				{
					Id = riskLevel.Id,
					Code = riskLevel.Code,
					Color = riskLevel.Color,
					Sequence = riskLevel.Sequence,
					Name = localization.Name
				};

			return query.ToList();
		}

		public RiskLevelForWeb GetRiskLevelForWeb(Guid riskLevelId, string language)
		{
			var query =
				from riskLevel in Context.RiskLevels
				where riskLevel.IsActive && riskLevel.Id == riskLevelId
				from localization in riskLevel.Localizations
				where localization.LanguageCode == language
				select new RiskLevelForWeb
				{
					Id = riskLevel.Id,
					Code = riskLevel.Code,
					Color = riskLevel.Color,
					Sequence = riskLevel.Sequence,
					Name = localization.Name
				};

			return query.SingleOrDefault();
		}
	}
}