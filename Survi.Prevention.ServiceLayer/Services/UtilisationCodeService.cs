using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class UtilisationCodeService : BaseService
	{
		public UtilisationCodeService(ManagementContext context) : base(context)
		{
		}

        public List<UtilisationCode> GetList()
        {
            var result = Context.UtilisationCodes
                        .Include(c => c.Localizations)
                        .ToList();

            return result;
        }

        public UtilisationCodeForWeb GetForWeb(Guid utilisationCodeId, string language)
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