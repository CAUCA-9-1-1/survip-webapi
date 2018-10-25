using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class UtilisationCodeService : BaseCrudService<UtilisationCode>
	{
		public UtilisationCodeService(ManagementContext context) : base(context)
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
                    Name = localization.Description
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
					Name = localization.Description
				};

			return query.SingleOrDefault();
		}
	}
}