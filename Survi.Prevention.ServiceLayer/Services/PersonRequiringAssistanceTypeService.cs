using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class PersonRequiringAssistanceTypeService : BaseCrudService<PersonRequiringAssistanceType>
	{
		public PersonRequiringAssistanceTypeService(ManagementContext context) : base(context)
		{
		}

        public override PersonRequiringAssistanceType Get(Guid id)
        {
            var result = Context.PersonRequiringAssistanceTypes
                .Include(r => r.Localizations)
                .First(r => r.Id == id);

            return result;
        }

        public override List<PersonRequiringAssistanceType> GetList()
        {
            var result = Context.PersonRequiringAssistanceTypes
				.Where(prat => prat.IsActive)
                .Include(r => r.Localizations)
                .ToList();

            return result;
        }

        public List<GenericModelForDisplay> GetListForDisplay(string languageCode)
		{
			var query =
				from type in Context.PersonRequiringAssistanceTypes.AsNoTracking()
				where type.IsActive
				from loc in type.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new GenericModelForDisplay
				{
					Id = type.Id,
					Name = loc.Name
				};

			return query.ToList();
		}
	}
}