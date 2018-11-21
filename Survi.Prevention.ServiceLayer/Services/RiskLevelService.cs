using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class RiskLevelService : BaseCrudServiceWithImportation<RiskLevel, ApiClient.DataTransferObjects.RiskLevel>
    {
		public RiskLevelService(
			IManagementContext context, 
			IEntityConverter<ApiClient.DataTransferObjects.RiskLevel, RiskLevel> converter) 
			: base(context, converter)
		{
		}

        public override RiskLevel Get(Guid id)
        {
            var result = Context.RiskLevels
                .Include(r => r.Localizations)
                .First(r => r.Id == id);

            return result;
        }

        public override List<RiskLevel> GetList()
        {
            var result = Context.RiskLevels
				.Where(rl => rl.IsActive)
                .Include(r => r.Localizations)
                .ToList();

            return result;
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