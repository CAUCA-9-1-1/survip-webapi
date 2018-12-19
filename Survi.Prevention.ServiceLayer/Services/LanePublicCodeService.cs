using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using ImportedPublicCode = Survi.Prevention.ApiClient.DataTransferObjects.LanePublicCode;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class LanePublicCodeService : BaseServiceWithGenericImportation
	{		
		public LanePublicCodeService(IManagementContext context,
			IEntityConverter<ImportedPublicCode, LanePublicCode> converter) : base(context)
		{
		    Converters.Add(converter);
		}

		public List<LanePublicCode> GetList()
		{
			var result = Context.LanePublicCodes.ToList();

			return result;
		}

	    public List<ImportationResult> ImportLanePublicCodes(List<ImportedPublicCode> importedLaneGenericCode)
	    {
	        return Import<LanePublicCode, ImportedPublicCode>(importedLaneGenericCode);
	    }
    }
}