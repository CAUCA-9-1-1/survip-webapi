using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class SprinklerTypeService 
        : BaseCrudServiceWithImportation<SprinklerType, ApiClient.DataTransferObjects.SprinklerType>
    {
	    public SprinklerTypeService(
	        IManagementContext context,
	        IEntityConverter<ApiClient.DataTransferObjects.SprinklerType, SprinklerType> converter)  
	        : base(context, converter)
	    {
	    }

		public List<GenericModelForDisplay> GetList(string languageCode)
		{
			var query =
				from type in Context.SprinklerTypes.AsNoTracking()
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
