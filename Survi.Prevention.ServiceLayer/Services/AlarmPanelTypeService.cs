using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class AlarmPanelTypeService 
	    : BaseCrudServiceWithImportation<AlarmPanelType, ApiClient.DataTransferObjects.AlarmPanelType>
    {
		public AlarmPanelTypeService(
		    IManagementContext context,
		    IEntityConverter<ApiClient.DataTransferObjects.AlarmPanelType, AlarmPanelType> converter)
		    : base(context, converter)
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