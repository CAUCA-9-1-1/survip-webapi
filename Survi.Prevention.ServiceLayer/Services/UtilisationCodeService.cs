using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class UtilisationCodeService : BaseCrudServiceWithImportation<UtilisationCode, ApiClient.DataTransferObjects.UtilisationCode>
	{
		public UtilisationCodeService(
			IManagementContext context, 
			IEntityConverter<ApiClient.DataTransferObjects.UtilisationCode, UtilisationCode> converter) 
			: base(context, converter)
		{
		}

        public override UtilisationCode Get(Guid id)
        {
            var result = Context.UtilisationCodes
                .Include(r => r.Localizations)
                .First(r => r.Id == id);

            return result;
        }

        public override List<UtilisationCode> GetList()
        {
            var result = Context.UtilisationCodes
				.Where(uc => uc.IsActive)
                .Include(r => r.Localizations)
                .ToList();

            return result;
        }

        public List<UtilisationCodeForWeb> GetListLocalized(string language)
        {
            var query =
                from code in Context.UtilisationCodes
                where code.IsActive
                from localization in code.Localizations
                where localization.LanguageCode == language
                select new UtilisationCodeForWeb
                {
                    Id = code.Id,
                    Name = localization.Name,
					Year =  code.Year
                };
            return query.ToList();
        }

		public List<UtilisationCodeForWeb> GetListLocalizedByCity(string language,Guid cityId)
        {
            var query =
                from code in Context.UtilisationCodes
                from localization in code.Localizations
				join city in Context.Cities on code.Year equals city.UtilizationCodeYear
                where localization.LanguageCode == language && code.IsActive
					  && city.Id == cityId
				select new UtilisationCodeForWeb
                {
                    Id = code.Id,
                    Name = localization.Name,
					Year =  code.Year
                };
            return query.ToList();
        }

        public UtilisationCodeForWeb GetUtilisationCodeForWeb(Guid utilisationCodeId, string language)
		{
			var query =
				from code in Context.UtilisationCodes
				where code.IsActive && code.Id == utilisationCodeId
				from localization in code.Localizations
				where localization.LanguageCode == language
				select new UtilisationCodeForWeb
				{
					Id = code.Id,
					Name = localization.Name,
					Year = code.Year
				};

			return query.SingleOrDefault();
		}
	}
}