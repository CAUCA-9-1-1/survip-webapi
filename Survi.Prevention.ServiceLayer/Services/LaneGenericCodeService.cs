using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireSafetyDepartments;
using importedGenericCode = Survi.Prevention.ApiClient.DataTransferObjects.LaneGenericCode;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class LaneGenericCodeService : BaseServiceWithGenericImportation
	{
		public LaneGenericCodeService(IManagementContext context,
			IEntityConverter<importedGenericCode, LaneGenericCode> converter) : base(context)
		{
		    Converters.Add(converter);
		}

		public List<LaneGenericCode> GetList()
		{
			var result = Context.LaneGenericCodes.ToList();
			return result;
		}

		public List<ImportationResult> ImportLaneGenericCodes(List<importedGenericCode> importedLaneGenericCode)
		{
		    return Import<LaneGenericCode, importedGenericCode>(importedLaneGenericCode);
		}
	}
}