using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class AlarmPanelTypeService : BaseService
	{
		public AlarmPanelTypeService(ManagementContext context) : base(context)
		{
		}

		public List<GenericModelForDisplay> GetList(string languageCode)
		{
			var query =
				from type in Context.AlarmPanelTypes.AsNoTracking()
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